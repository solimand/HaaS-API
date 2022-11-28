using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelDb>(opt => opt.UseInMemoryDatabase("AccomodationsList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todoitems", async (HotelDb db) =>
    await db.Accomodations.ToListAsync());

app.MapPost("/todoitems", async (Accomodation hotel, HotelDb db) =>
{
    db.Accomodations.Add(hotel);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{hotel.Id}", hotel);
});

app.MapDelete("/todoitems/{id}", async (int id, HotelDb db) =>
{
    if (await db.Accomodations.FindAsync(id) is Accomodation hotel)
    {
        db.Accomodations.Remove(hotel);
        await db.SaveChangesAsync();
        return Results.Ok(hotel);
    }

    return Results.NotFound();
});


app.Run();
