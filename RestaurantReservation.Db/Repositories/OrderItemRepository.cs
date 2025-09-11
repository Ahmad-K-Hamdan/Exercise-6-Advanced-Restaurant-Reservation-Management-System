using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public OrderItem? GetById(int orderItemId)
        {
            return _context.OrderItems.FirstOrDefault(oi => oi.OrderItemId == orderItemId);
        }

        public void Update(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();
        }

        public void Delete(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }

        public bool IsEmpty()
        {
            return !_context.OrderItems.Any();
        }
    }
}
