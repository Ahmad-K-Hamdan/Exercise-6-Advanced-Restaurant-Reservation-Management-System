using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public bool IsEmpty()
        {
            return !_context.Restaurants.Any();
        }

        public Restaurant? GetById(int id)
        {
            return _context.Restaurants.FirstOrDefault(rest => rest.RestaurantId == id);
        }

        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
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
    }
}
