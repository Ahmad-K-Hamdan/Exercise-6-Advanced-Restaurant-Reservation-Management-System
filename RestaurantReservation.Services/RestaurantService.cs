﻿using RestaurantReservation.Db.Models;
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

        public async Task<List<Restaurant>> ViewAllAsync()
        {
            return await _restaurantRepo.GetAllAsync();
        }

        public async Task<Restaurant> AddAsync(string name, string address, string phoneNumber, string openingHours)
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

            return await _restaurantRepo.AddAsync(newRestaurant);
        }

        public async Task DeleteAsync(int restaurantId)
        {
            var restaurant = await GetRestaurantByIdAsync(restaurantId);
            await _restaurantRepo.DeleteAsync(restaurant);
        }

        public async Task<Restaurant> UpdateAsync(int restaurantId, string name, string address, string phoneNumber, string openingHours)
        {
            var restaurant = await GetRestaurantByIdAsync(restaurantId);

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

            return await _restaurantRepo.UpdateAsync(restaurant);
        }

        public async Task<decimal> CalculateRestaurantRevenueAsync(int restaurantId)
        {
            var restaurant = await GetRestaurantByIdAsync(restaurantId);
            return await _restaurantRepo.GetRestaurantRevenueAsync(restaurantId);
        }

        private async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepo.GetByIdAsync(restaurantId);
            if (restaurant == null)
            {
                throw new InvalidOperationException($"Restaurant with ID {restaurantId} not found.");
            }
            return restaurant;
        }
    }
}
