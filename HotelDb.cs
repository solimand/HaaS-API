using Microsoft.EntityFrameworkCore;

class HotelDb : DbContext
{
    public HotelDb(DbContextOptions<HotelDb> options)
        : base(options) { }

    public DbSet<Accomodation> Accomodations => Set<Accomodation>();
}