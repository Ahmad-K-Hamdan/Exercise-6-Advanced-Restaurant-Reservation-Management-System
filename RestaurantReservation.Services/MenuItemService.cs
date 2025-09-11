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

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo menu items found.");
                return;
            }

            var items = _menuItemRepo.GetAll();
            Console.WriteLine("\nAll Menu Items:");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _menuItemRepo.IsEmpty();
        }
    }
}
