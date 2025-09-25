using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.MainServices
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

        public List<MenuItem> ViewAll()
        {
            return _menuItemRepo.GetAll();
        }

        public MenuItem Add(int restaurantId, string name, string description, decimal price)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var menuItemName = MenuItemValidator.ValidateMenuItemName(name);
            if (menuItemName != null)
            {
                throw new ArgumentException(menuItemName);
            }
            var menuItemDescription = MenuItemValidator.ValidateDescription(description);
            if (menuItemDescription != null)
            {
                throw new ArgumentException(menuItemDescription);
            }
            var menuItemPrice = MenuItemValidator.ValidatePrice(price.ToString());
            if (menuItemPrice != null)
            {
                throw new ArgumentException(menuItemPrice);
            }

            var newMenuItem = new MenuItem
            {
                RestaurantId = restaurantId,
                Name = name,
                Description = description,
                Price = price,
                Restaurant = restaurant
            };

            _menuItemRepo.Add(newMenuItem);
            return newMenuItem;
        }

        public void Delete(int menuItemId)
        {
            var menuItem = GetMenuItemById(menuItemId);
            _menuItemRepo.Delete(menuItem);
        }

        public MenuItem Update(int menuItemId, string name, string description, decimal price)
        {
            var menuItem = GetMenuItemById(menuItemId);

            var menuItemName = MenuItemValidator.ValidateMenuItemName(name);
            if (menuItemName != null)
            {
                throw new ArgumentException(menuItemName);
            }
            var menuItemDescription = MenuItemValidator.ValidateDescription(description);
            if (menuItemDescription != null)
            {
                throw new ArgumentException(menuItemDescription);
            }
            var menuItemPrice = MenuItemValidator.ValidatePrice(price.ToString());
            if (menuItemPrice != null)
            {
                throw new ArgumentException(menuItemPrice);
            }

            menuItem.Name = name;
            menuItem.Description = description;
            menuItem.Price = price;

            _menuItemRepo.Update(menuItem);
            return menuItem;
        }

        private MenuItem GetMenuItemById(int menuItemId)
        {
            var menuItem = _menuItemRepo.GetById(menuItemId);
            if (menuItem == null)
            {
                throw new InvalidOperationException($"Menu item with ID {menuItemId} not found.");
            }
            return menuItem;
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