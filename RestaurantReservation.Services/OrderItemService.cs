using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository _orderItemRepo;

        public OrderItemService(OrderItemRepository OrderItemRepo)
        {
            _orderItemRepo = OrderItemRepo;
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

        private bool IsEmpty()
        {
            return _orderItemRepo.IsEmpty();
        }
    }
}
