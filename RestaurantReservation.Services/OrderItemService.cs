using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

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
                var orderId = InputHelper.GetValidOrderId(_orderRepo);
                var order = _orderRepo.GetById(orderId);

                var menuItemId = InputHelper.GetValidMenuItemId(_menuItemRepo);
                var menuItem = _menuItemRepo.GetById(menuItemId);

                var quantityInput = InputHelper.GetValidInput(ValidationMessages.EnterQuantity, OrderItemValidator.ValidateQuantity);
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

        public void Delete()
        {
            Console.WriteLine();
            try
            {
                var orderItemId = InputHelper.GetValidOrderItemId(_orderItemRepo);
                var orderItem = _orderItemRepo.GetById(orderItemId);

                if (orderItem == null)
                {
                    Console.WriteLine($"Order item with ID {orderItemId} not found.");
                }
                else
                {
                    _orderItemRepo.Delete(orderItem);
                    Console.WriteLine($"Order item with ID {orderItemId} deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order item: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _orderItemRepo.IsEmpty();
        }
    }
}
