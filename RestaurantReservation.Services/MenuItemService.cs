using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

namespace RestaurantReservation.Services
{
    public class MenuItemService
    {
        private readonly MenuItemRepository _menuItemRepo;
        private readonly RestaurantRepository _restaurantRepo;

        public MenuItemService(MenuItemRepository menuItemRepo, RestaurantRepository restaurantRepo)
        {
            _menuItemRepo = menuItemRepo;
            _restaurantRepo = restaurantRepo;
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
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void Add()
        {
            Console.WriteLine();

            try
            {
                var restaurantId = InputHelper.GetValidRestaurantId(_restaurantRepo);
                var restaurant = _restaurantRepo.GetById(restaurantId);

                var name = InputHelper.GetValidInput(ValidationMessages.EnterMenuItemName, MenuItemValidator.ValidateMenuItemName);
                var description = InputHelper.GetValidInput(ValidationMessages.EnterDescription, MenuItemValidator.ValidateDescription);
                var priceInput = InputHelper.GetValidInput(ValidationMessages.EnterPrice, MenuItemValidator.ValidatePrice);
                var price = decimal.Parse(priceInput);

                var newMenuItem = new MenuItem
                {
                    RestaurantId = restaurantId,
                    Name = name,
                    Description = description,
                    Price = price,
                    Restaurant = restaurant!
                };

                _menuItemRepo.Add(newMenuItem);
                Console.WriteLine($"Menu item '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding menu item: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void Delete()
        {
            Console.WriteLine();
            try
            {
                var menuItemId = InputHelper.GetValidMenuItemId(_menuItemRepo);
                var menuItem = _menuItemRepo.GetById(menuItemId);

                if (menuItem == null)
                {
                    Console.WriteLine($"Menu item with ID {menuItemId} not found.");
                }
                else
                {
                    _menuItemRepo.Delete(menuItem);
                    Console.WriteLine($"Menu item with ID {menuItemId} deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting menu item: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void Update()
        {
            Console.WriteLine();
            try
            {
                var menuItemId = InputHelper.GetValidMenuItemId(_menuItemRepo);
                var menuItem = _menuItemRepo.GetById(menuItemId);

                if (menuItem == null)
                {
                    Console.WriteLine($"Menu item with ID {menuItemId} not found.");
                    return;
                }

                Console.WriteLine($"Managing Menu Item: {menuItem}");

                var name = InputHelper.GetValidInput(ValidationMessages.EnterMenuItemName, MenuItemValidator.ValidateMenuItemName);
                var description = InputHelper.GetValidInput(ValidationMessages.EnterDescription, MenuItemValidator.ValidateDescription);
                var priceInput = InputHelper.GetValidInput(ValidationMessages.EnterPrice, MenuItemValidator.ValidatePrice);
                var price = decimal.Parse(priceInput);

                menuItem.Name = name;
                menuItem.Description = description;
                menuItem.Price = price;

                _menuItemRepo.Update(menuItem);
                Console.WriteLine($"Menu item with ID {menuItemId} updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error managing menu item: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _menuItemRepo.IsEmpty();
        }
    }
}
