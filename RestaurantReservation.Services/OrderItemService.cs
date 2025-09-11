using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository _orderItem;

        public OrderItemService(OrderItemRepository OrderItemRepo)
        {
            _orderItem = OrderItemRepo;
        }
    }
}
