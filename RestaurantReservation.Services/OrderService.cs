using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo;

        public OrderService(OrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
    }
}
