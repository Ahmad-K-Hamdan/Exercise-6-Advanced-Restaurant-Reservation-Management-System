using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepo;

        public ReservationService(ReservationRepository reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }
    }
}
