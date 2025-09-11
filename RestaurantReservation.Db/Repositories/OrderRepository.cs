using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order? GetById(int OrderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == OrderId);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public bool IsEmpty()
        {
            return !_context.Orders.Any();
        }
    }
}
