using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Core.DTOs;
using RestaurantReservation.Db.Models;

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

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<CustomerDetailsDTO> FindCustomersByPartySize(int minPartySize)
        {
            try
            {
                var customers = _context.Database
                    .SqlQuery<CustomerDetailsDTO>(
                        $"EXEC ListAllCusWithMinPartySize @MinPartySize = {minPartySize}"
                    ).ToList();
                return customers;
            }
            catch (Exception)
            {
                return new List<CustomerDetailsDTO>();
            }
        }
    }
}
