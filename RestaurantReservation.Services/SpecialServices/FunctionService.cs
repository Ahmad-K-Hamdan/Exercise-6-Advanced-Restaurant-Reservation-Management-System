using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

namespace RestaurantReservation.Services.SpecialServices
{
    public class FunctionService
    {
        private readonly FunctionRepository _functionRepo;
        private readonly RestaurantRepository _restaurantRepo;

        public FunctionService(FunctionRepository functionRepo, RestaurantRepository restaurantRepo)
        {
            _functionRepo = functionRepo;
            _restaurantRepo = restaurantRepo;
        }

        public void CalculateRestaurantRevenue()
        {
            Console.WriteLine();
            try
            {
                var restaurantId = InputHelper.GetValidRestaurantId(_restaurantRepo);
                var revenue = _functionRepo.GetRestaurantRevenue(restaurantId);

                if (revenue == 0)
                {
                    Console.WriteLine($"Restaurant {restaurantId} has made no revenue so far.");
                }

                Console.WriteLine($"Restaurant {restaurantId} total revenue = {revenue:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating restaurant revenue: {ex.Message}");
            }
        }
    }
}