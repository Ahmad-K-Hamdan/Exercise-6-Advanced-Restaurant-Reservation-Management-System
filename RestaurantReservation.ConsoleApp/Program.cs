using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services;

namespace RestaurantReservation.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create service collection and configure services
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Ensure database is created and connection is established
            if (!InitializeDatabase(serviceProvider))
            {
                return;
            }

            // Start the program
            var userMenu = serviceProvider.GetRequiredService<UserMenu>();
            userMenu.ShowMainMenu();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<RestaurantReservationDbContext>();

            // Register Repositories 
            services.AddScoped<RestaurantRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<MenuItemRepository>();
            services.AddScoped<OrderItemRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<ReservationRepository>();
            services.AddScoped<TableRepository>();

            // Register Services
            services.AddScoped<RestaurantService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<MenuItemService>();
            services.AddScoped<OrderItemService>();
            services.AddScoped<OrderService>();
            services.AddScoped<ReservationService>();
            services.AddScoped<TableService>();

            // Register Main Menu
            services.AddScoped<UserMenu>();
        }

        private static bool InitializeDatabase(IServiceProvider serviceProvider)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<RestaurantReservationDbContext>();
                    context.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while connecting to the database: {ex.Message}");
                return false;
            }
            return true;
        }
    }
}