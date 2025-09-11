using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepo;

        public RestaurantService(RestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo restaurants found.");
                return;
            }

            var restaurants = _restaurantRepo.GetAll();
            Console.WriteLine("\nAll Restaurants:");
            foreach (var rest in restaurants)
            {
                Console.WriteLine(rest.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _restaurantRepo.IsEmpty();
        }
    }
}
