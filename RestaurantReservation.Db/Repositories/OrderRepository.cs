using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetById(int OrderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == OrderId);
        }

        public async Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<Order> GetOrdersByReservationId(int reservationId)
        {
            return _context.Orders.Where(o => o.ReservationId == reservationId).Include(o => o.OrderItems).ToList();
        }

        public decimal CalculateAverageOrderAmountByEmployee(int employeeId)
        {
            var orders = _context.Orders.Where(o => o.EmployeeId == employeeId).ToList();
            if (orders.Count == 0)
            {
                return 0;
            }
            return orders.Average(o => o.TotalAmount);
        }
    }
}
