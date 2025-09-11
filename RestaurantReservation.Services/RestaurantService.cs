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
                Console.WriteLine("No restaurants found.");
                return;
            }

            var restaurants = _restaurantRepo.GetAll();
            Console.WriteLine("All Restaurants:");
            foreach (var rest in restaurants)
            {
                Console.WriteLine($"Id: {rest.RestaurantId} | Name: {rest.Name} | Address: {rest.Address} | Phone: {rest.PhoneNumber} | OpeningHours: {rest.OpeningHours}");
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
