using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

namespace RestaurantReservation.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly RestaurantRepository _restaurantRepo;
        private readonly TableRepository _tableRepo;

        public ReservationService(ReservationRepository reservationRepo, CustomerRepository customerRepo, RestaurantRepository restaurantRepo, TableRepository tableRepo)
        {
            _reservationRepo = reservationRepo;
            _customerRepo = customerRepo;
            _restaurantRepo = restaurantRepo;
            _tableRepo = tableRepo;
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

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var customerId = InputHelper.GetValidCustomerId(_customerRepo);
                var customer = _customerRepo.GetById(customerId);

                var restaurantId = InputHelper.GetValidRestaurantId(_restaurantRepo);
                var restaurant = _restaurantRepo.GetById(restaurantId);

                var tableId = InputHelper.GetValidTableId(_tableRepo);
                var table = _tableRepo.GetById(tableId);

                var reservationDateInput = InputHelper.GetValidInput(ValidationMessages.EnterReservationDate, ReservationValidator.ValidateReservationDate);
                var reservationDate = DateTime.Parse(reservationDateInput);

                var partySizeInput = InputHelper.GetValidInput(ValidationMessages.EnterPartySize, ReservationValidator.ValidatePartySize);
                var partySize = int.Parse(partySizeInput);

                var newReservation = new Reservation
                {
                    CustomerId = customerId,
                    RestaurantId = restaurantId,
                    TableId = tableId,
                    ReservationDate = reservationDate,
                    PartySize = partySize,
                    Customer = customer!,
                    Restaurant = restaurant!,
                    Table = table!
                };

                _reservationRepo.Add(newReservation);
                Console.WriteLine($"Reservation for {partySize} people added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding reservation: {ex.Message}");
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
