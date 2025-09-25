using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> AddAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task<MenuItem?> GetById(int ItemId)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(mi => mi.ItemId == ItemId);
        }

        public void Update(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges();
        }

        public void Delete(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }
    }
}
