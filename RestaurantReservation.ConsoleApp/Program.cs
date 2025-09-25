using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Services;
using RestaurantReservation.Services.Interfaces;

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
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<RestaurantReservationDbContext>();

            // Register Repository Interfaces with their Implementations
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ITableRepository, TableRepository>();

            // Register Service Interfaces with their Implementations
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ITableService, TableService>();
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