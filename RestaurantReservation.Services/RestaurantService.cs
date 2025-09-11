using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
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

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var name = GetValidInput(ValidationMessages.EnterRestaurantName, RestaurantValidator.ValidateRestaurantName);
                var address = GetValidInput(ValidationMessages.EnterRestaurantAddress, RestaurantValidator.ValidateAddress);
                var phoneNumber = GetValidInput(ValidationMessages.EnterRestaurantPhone, RestaurantValidator.ValidatePhoneNumber);
                var openingHours = GetValidInput(ValidationMessages.EnterOpeningHours, RestaurantValidator.ValidateTimeSpan);

                var newRestaurant = new Restaurant
                {
                    Name = name,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    OpeningHours = TimeSpan.Parse(openingHours)
                };

                _restaurantRepo.Add(newRestaurant);
                Console.WriteLine($"Restaurant '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding restaurant: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _restaurantRepo.IsEmpty();
        }

        private string GetValidInput(string prompt, Func<string, string?> validator)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim()!;

                var errorMessage = validator(input);
                if (errorMessage == null)
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
