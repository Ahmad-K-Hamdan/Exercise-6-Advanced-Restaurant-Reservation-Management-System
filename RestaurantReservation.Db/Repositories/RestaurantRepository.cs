using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> AddAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Restaurant?> GetByIdAsync(int RestaurantId)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(rest => rest.RestaurantId == RestaurantId);
        }

        public void Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }

        public void Delete(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        public decimal GetRestaurantRevenue(int restaurantId)
        {
            try
            {
                var revenue = _context.Database
                    .SqlQuery<decimal>($"SELECT dbo.CalcTotalRevenue({restaurantId}) AS Value")
                    .FirstOrDefault();
                return revenue;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
