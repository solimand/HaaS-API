using Microsoft.EntityFrameworkCore;

class HotelDb : DbContext
{
    public HotelDb(DbContextOptions<HotelDb> options)
        : base(options) { }

    public DbSet<Accomodation> Accomodations => Set<Accomodation>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    //public DbSet<Price> RoomTypePrices => Set<Price>();
}