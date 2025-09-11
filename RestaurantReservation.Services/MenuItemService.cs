using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class MenuItemService
    {
        private readonly MenuItemRepository _menuItemRepo;

        public MenuItemService(MenuItemRepository MenuItemRepo)
        {
            _menuItemRepo = MenuItemRepo;
        }
    }
}
