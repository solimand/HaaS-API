using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelDb>(opt => opt.UseInMemoryDatabase("AccomodationsList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

/* TEST Page */
app.MapGet("/", () => "Hello World!");

/* READ API */
app.MapGet("/hotels", async (HotelDb db) =>
    await db.Accomodations.ToListAsync());

/* CREATE API */
app.MapPost("/hotels", async (Accomodation hotel, HotelDb db) =>
{
    db.Accomodations.Add(hotel);
    await db.SaveChangesAsync();

    return Results.Created($"/hotels/{hotel.Id}", hotel);
});

/* DELETE API */
app.MapDelete("/hotels/{id}", async (int id, HotelDb db) =>
{
    if (await db.Accomodations.FindAsync(id) is Accomodation hotel)
    {
        db.Accomodations.Remove(hotel);
        await db.SaveChangesAsync();
        return Results.Ok(hotel);
    }

    return Results.NotFound();
});

/* UPDATE API */
app.MapPut("/hotels/{id}", async (int id, Accomodation inputHotel, HotelDb db) =>
{
    var hotel = await db.Accomodations.FindAsync(id);

    if (hotel is null) return Results.NotFound();

    hotel.Name = inputHotel.Name;
    hotel.RoomType = inputHotel.RoomType;

    await db.SaveChangesAsync();

    return Results.NoContent();     // save and continue functionality -> user doesn't need to navigate away
});

app.Run();
