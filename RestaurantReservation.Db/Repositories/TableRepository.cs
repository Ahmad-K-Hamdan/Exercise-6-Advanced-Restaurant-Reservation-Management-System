using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<Table> GetAll()
        {
            return _context.Tables.ToList();
        }

        public bool IsEmpty()
        {
            return !_context.Restaurants.Any();
        }
    }
}
