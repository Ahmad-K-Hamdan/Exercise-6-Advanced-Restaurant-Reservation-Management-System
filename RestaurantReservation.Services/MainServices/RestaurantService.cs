using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.MainServices
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepo;

        public RestaurantService(RestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public List<Restaurant> ViewAll()
        {
            return _restaurantRepo.GetAll();
        }

        public Restaurant Add(string name, string address, string phoneNumber, string openingHours)
        {
            var restName = RestaurantValidator.ValidateRestaurantName(name);
            if (restName != null)
            {
                throw new ArgumentException(restName);
            }
            var restAddress = RestaurantValidator.ValidateAddress(address);
            if (restAddress != null)
            {
                throw new ArgumentException(restAddress);
            }
            var restPhoneNumber = RestaurantValidator.ValidatePhoneNumber(phoneNumber);
            if (restPhoneNumber != null)
            {
                throw new ArgumentException(restPhoneNumber);
            }
            var restOpeningHours = RestaurantValidator.ValidateTimeSpan(openingHours);
            if (restOpeningHours != null)
            {
                throw new ArgumentException(restOpeningHours);
            }

            var newRestaurant = new Restaurant
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                OpeningHours = TimeSpan.Parse(openingHours)
            };

            _restaurantRepo.Add(newRestaurant);
            return newRestaurant;
        }

        public void Delete(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);
            _restaurantRepo.Delete(restaurant);
        }

        public Restaurant Update(int restaurantId, string name, string address, string phoneNumber, string openingHours)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var restName = RestaurantValidator.ValidateRestaurantName(name);
            if (restName != null)
            {
                throw new ArgumentException(restName);
            }
            var restAddress = RestaurantValidator.ValidateAddress(address);
            if (restAddress != null)
            {
                throw new ArgumentException(restAddress);
            }
            var restPhoneNumber = RestaurantValidator.ValidatePhoneNumber(phoneNumber);
            if (restPhoneNumber != null)
            {
                throw new ArgumentException(restPhoneNumber);
            }
            var restOpeningHours = RestaurantValidator.ValidateTimeSpan(openingHours);
            if (restOpeningHours != null)
            {
                throw new ArgumentException(restOpeningHours);
            }

            restaurant.Name = name;
            restaurant.Address = address;
            restaurant.PhoneNumber = phoneNumber;
            restaurant.OpeningHours = TimeSpan.Parse(openingHours);

            _restaurantRepo.Update(restaurant);
            return restaurant;
        }

        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _restaurantRepo.GetById(restaurantId);
            if (restaurant == null)
            {
                throw new InvalidOperationException($"Restaurant with ID {restaurantId} not found.");
            }
            return restaurant;
        }
    }
}
