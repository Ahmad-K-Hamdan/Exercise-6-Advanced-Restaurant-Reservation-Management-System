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
    }
}
