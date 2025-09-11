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

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo orders found.");
                return;
            }

            var orders = _orderRepo.GetAll();
            Console.WriteLine("\nAll Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _orderRepo.IsEmpty();
        }
    }
}
