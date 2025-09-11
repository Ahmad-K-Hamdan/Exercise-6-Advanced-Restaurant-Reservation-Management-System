using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo customers found.");
                return;
            }

            var customers = _customerRepo.GetAll();
            Console.WriteLine("\nAll Customers:");
            foreach (var cust in customers)
            {
                Console.WriteLine(cust.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _customerRepo.IsEmpty();
        }
    }
}
