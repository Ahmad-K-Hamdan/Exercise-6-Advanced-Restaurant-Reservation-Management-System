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

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo reservations found.");
                return;
            }

            var reservations = _reservationRepo.GetAll();
            Console.WriteLine("\nAll Reservations:");
            foreach (var res in reservations)
            {
                Console.WriteLine(res.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _reservationRepo.IsEmpty();
        }
    }
}
