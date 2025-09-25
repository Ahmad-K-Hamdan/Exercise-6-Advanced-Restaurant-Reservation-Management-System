using System.Threading.Tasks;
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

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetByIdAsync(int CustomerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(cus => cus.CustomerId == CustomerId);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerDetailsDTO>> FindCustomersByPartySize(int minPartySize)
        {
            try
            {
                var customers = await _context.Database
                    .SqlQuery<CustomerDetailsDTO>(
                        $"EXEC ListAllCusWithMinPartySize @MinPartySize = {minPartySize}"
                    ).ToListAsync();
                return customers;
            }
            catch (Exception)
            {
                return new List<CustomerDetailsDTO>();
            }
        }
    }
}
