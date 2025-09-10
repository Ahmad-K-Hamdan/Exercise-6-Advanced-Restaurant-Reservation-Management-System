using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

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

            // An issue occurs with Restaurant model in which it can't define 
            // the primary key on it's own
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(r => r.RestaurantId);
                entity.Property(r => r.Name).IsRequired();
                entity.Property(r => r.Address).IsRequired();
                entity.Property(r => r.PhoneNumber).IsRequired();
                entity.Property(r => r.OpeningHours).IsRequired();
            });

            // The primary key in MenuItem model does not follow EF rules
            // so it has to be defined manually
            modelBuilder.Entity<MenuItem>().HasKey(menuItem => menuItem.ItemId);

            // Orders deleted when Reservation is deleted
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reservation)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.ReservationId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // OrderItems deleted when Order is deleted
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // No action for deletion: restaurant -> reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Restaurant)
                .WithMany(rt => rt.Reservations)
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
