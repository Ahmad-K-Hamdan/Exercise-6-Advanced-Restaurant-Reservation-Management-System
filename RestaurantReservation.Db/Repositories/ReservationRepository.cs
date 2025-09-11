using RestaurantReservation.Core.Models;

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

        public bool IsEmpty()
        {
            return !_context.Reservations.Any();
        }
    }
}
