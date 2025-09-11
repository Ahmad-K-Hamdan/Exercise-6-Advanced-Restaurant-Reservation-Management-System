using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services;

namespace RestaurantReservation.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ensure database is created and connection is established
            InitializeDatabase();

            // Initialize services and repositories
            using var context = new RestaurantReservationDbContext();
            var allRepos = new AllRepositories(context);
            var allServices = new AllServices(allRepos);

            UserMenu.ShowMainMenu(allServices);
        }

        private static void InitializeDatabase()
        {
            try
            {
                using (var context = new RestaurantReservationDbContext())
                {
                    context.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while connecting to the database: {ex.Message}");
            }
            Console.WriteLine("Database connection established successfully.");
        }
    }
}