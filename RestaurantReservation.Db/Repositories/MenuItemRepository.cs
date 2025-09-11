using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }

        public void Add(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }

        public MenuItem? GetById(int ItemId)
        {
            return _context.MenuItems.FirstOrDefault(mi => mi.ItemId == ItemId);
        }

        public bool IsEmpty()
        {
            return !_context.MenuItems.Any();
        }
    }
}
