using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RestaurantReservationCore"
            ).LogTo(Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(r => r.RestaurantId);
                entity.Property(r => r.Name).IsRequired();
                entity.Property(r => r.Address).IsRequired();
                entity.Property(r => r.PhoneNumber).IsRequired();
                entity.Property(r => r.OpeningHours).IsRequired();
            });

            modelBuilder.Entity<MenuItem>().HasKey(menuItem => menuItem.ItemId);
        }
    }
}
