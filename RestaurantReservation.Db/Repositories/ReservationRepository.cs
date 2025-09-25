using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.DTOs;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation?> GetByIdAsync(int ReservationId)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationId == ReservationId);
        }

        public async Task<Reservation> Update(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
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

        public List<ReservationDetailsDTO> GetReservationDetails()
        {
            return _context.ReservationDetailsView.ToList();
        }
    }
}
