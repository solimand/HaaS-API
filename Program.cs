using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString1 = "(localdb)\\MSSQLLocalDB;Initial Catalog=AccomodationsList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 
var connString2 = "Data Source=(localdb)\\MSSQLLocalDB;Database=AccomodationsList;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

builder.Services.AddDbContext<HotelDb>(opt => opt.UseSqlServer(connString2));
// builder.Services.AddDbContext<HotelDb>(opt => opt.UseInMemoryDatabase("AccomodationsList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

/* DEV TEST with TypedResults (and MapGroups) 
*  Unit tests can call these methods and test that they return the correct type.
*/
// var hotelsItems = app.MapGroup("/hotels");
// hotelsItems.MapGet("/", GetAllHotels);
// static async Task<IResult> GetAllHotels(HotelDb db)
// {
//     return TypedResults.Ok(await db.Accomodations.ToArrayAsync());
// }

/* TEST Page */
app.MapGet("/", () => "Hello World!");

/* READ API */
app.MapGet("/hotels", async (HotelDb db) =>
    await db.Accomodations.Include(x  => x.Rooms)
    .ThenInclude(y => y.RoomType)
    .ThenInclude(z => z.Price)
    .ToListAsync());

/* CREATE API */
app.MapPost("/hotels", async (Accomodation hotel, HotelDb db) =>
{
    db.Rooms.AddRange(hotel.Rooms);
    foreach(var currRoom in hotel.Rooms){
        db.RoomTypes.Add(currRoom.RoomType);
    }
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
    hotel.Rooms = inputHotel.Rooms;

    await db.SaveChangesAsync();
    return Results.NoContent();     // save and continue functionality -> user doesn't need to navigate away
});

app.Run();
