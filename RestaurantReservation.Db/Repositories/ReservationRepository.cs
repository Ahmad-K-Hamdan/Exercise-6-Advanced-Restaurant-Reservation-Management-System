using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.DTOs;


namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public void Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public Reservation? GetById(int ReservationId)
        {
            return _context.Reservations.FirstOrDefault(r => r.ReservationId == ReservationId);
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        public List<Reservation> GetByCustomerId(int CustomerId)
        {
            return _context.Reservations.Where(res => res.CustomerId == CustomerId).ToList();
        }

        public List<Order> ListOrdersAndMenuItems(int ReservationId)
        {
            return _context.Orders.Where(o => o.ReservationId == ReservationId)
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                    .ToList();
        }

        public List<OrderedMenuItemDTO> ListOrderedMenuItems(int reservationId)
        {
            return _context.OrderItems.Where(oi => oi.Order.ReservationId == reservationId)
                    .Include(oi => oi.MenuItem)
                    .Include(oi => oi.Order)
                    .Select(oi => new OrderedMenuItemDTO
                    {
                        MenuItemName = oi.MenuItem.Name,
                        Price = oi.MenuItem.Price,
                        Quantity = oi.Quantity,
                    }).ToList();
        }

        public bool IsEmpty()
        {
            return !_context.Reservations.Any();
        }
    }
}
