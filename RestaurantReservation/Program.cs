using RestaurantReservation.Db;

namespace RestaurantReservation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Ensure database is created and connection is established
            InitializeDatabase();

            UserMenu.ShowMainMenu();
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