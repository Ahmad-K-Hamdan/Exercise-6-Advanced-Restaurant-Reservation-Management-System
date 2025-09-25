using RestaurantReservation.Core.Constants;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.MainServices
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

        public List<OrderItem> ViewAll()
        {
            return _orderItemRepo.GetAll();
        }

        public OrderItem Add(int orderId, int menuItemId, int quantity)
        {
            var order = GetOrderById(orderId);
            var menuItem = GetMenuItemById(menuItemId);

            var quantityValidation = OrderItemValidator.ValidateQuantity(quantity.ToString());
            if (quantityValidation != null)
            {
                throw new ArgumentException(quantityValidation);
            }

            var newOrderItem = new OrderItem
            {
                OrderId = orderId,
                ItemId = menuItemId,
                Quantity = quantity,
                Order = order,
                MenuItem = menuItem
            };

            _orderItemRepo.Add(newOrderItem);
            return newOrderItem;
        }

        public void Delete(int orderItemId)
        {
            var orderItem = GetOrderItemById(orderItemId);
            _orderItemRepo.Delete(orderItem);
        }

        public OrderItem Update(int orderItemId, int quantity)
        {
            var orderItem = GetOrderItemById(orderItemId);

            var quantityValidation = OrderItemValidator.ValidateQuantity(quantity.ToString());
            if (quantityValidation != null)
            {
                throw new ArgumentException(quantityValidation);
            }

            orderItem.Quantity = quantity;
            _orderItemRepo.Update(orderItem);
            return orderItem;
        }

        private OrderItem GetOrderItemById(int orderItemId)
        {
            var orderItem = _orderItemRepo.GetById(orderItemId);
            if (orderItem == null)
            {
                throw new InvalidOperationException($"Order item with ID {orderItemId} not found.");
            }
            return orderItem;
        }

        private Order GetOrderById(int orderId)
        {
            var order = _orderRepo.GetById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} not found.");
            }
            return order;
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
    }
}