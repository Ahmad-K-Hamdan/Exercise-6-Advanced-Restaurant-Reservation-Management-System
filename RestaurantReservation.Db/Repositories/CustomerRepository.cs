using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer? GetById(int CustomerId)
        {
            return _context.Customers.FirstOrDefault(cus => cus.CustomerId == CustomerId);
        }

        public bool IsEmpty()
        {
            return !_context.Customers.Any();
        }
    }
}
