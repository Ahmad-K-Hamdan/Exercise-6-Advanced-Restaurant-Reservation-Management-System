using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository _orderItemRepo;
        private readonly OrderRepository _orderRepo;
        private readonly MenuItemRepository _menuItemRepo;

        public OrderItemService(OrderItemRepository orderItemRepo, OrderRepository orderRepo, MenuItemRepository menuItemRepo)
        {
            _orderItemRepo = orderItemRepo;
            _orderRepo = orderRepo;
            _menuItemRepo = menuItemRepo;
        }

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo order items found.");
                return;
            }

            var orderItems = _orderItemRepo.GetAll();
            Console.WriteLine("\nAll Order Items:");
            foreach (var oi in orderItems)
            {
                Console.WriteLine(oi.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var orderId = GetValidOrderId();
                var order = _orderRepo.GetById(orderId);

                var menuItemId = GetValidMenuItemId();
                var menuItem = _menuItemRepo.GetById(menuItemId);

                var quantityInput = GetValidInput(ValidationMessages.EnterQuantity, OrderItemValidator.ValidateQuantity);
                var quantity = int.Parse(quantityInput);

                var newOrderItem = new OrderItem
                {
                    OrderId = orderId,
                    ItemId = menuItemId,
                    Quantity = quantity,
                    Order = order!,
                    MenuItem = menuItem!
                };

                _orderItemRepo.Add(newOrderItem);
                Console.WriteLine($"Order item with quantity {quantity} added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order item: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _orderItemRepo.IsEmpty();
        }

        private int GetValidOrderId()
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterOrderId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var order = _orderRepo.GetById(id);
                    if (order != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.OrderNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        private int GetValidMenuItemId()
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterMenuItemId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var menuItem = _menuItemRepo.GetById(id);
                    if (menuItem != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.MenuItemNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        private string GetValidInput(string prompt, Func<string, string?> validator)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim()!;

                var errorMessage = validator(input);
                if (errorMessage == null)
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
