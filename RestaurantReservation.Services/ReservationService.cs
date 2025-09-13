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
        }

        public void Delete()
        {
            Console.WriteLine();
            try
            {
                var reservationId = InputHelper.GetValidReservationId(_reservationRepo);
                var reservation = _reservationRepo.GetById(reservationId);

                if (reservation == null)
                {
                    Console.WriteLine("Reservation not found.");
                }
                else
                {
                    _reservationRepo.Delete(reservation);
                    Console.WriteLine($"Reservation with ID {reservationId} deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting reservation: {ex.Message}");
            }
        }

        public void Update()
        {
            Console.WriteLine();
            try
            {
                var reservationId = InputHelper.GetValidReservationId(_reservationRepo);
                var reservation = _reservationRepo.GetById(reservationId);

                if (reservation == null)
                {
                    Console.WriteLine("Reservation not found.");
                    return;
                }

                Console.WriteLine($"Managing Reservation: {reservation}");

                var reservationDateInput = InputHelper.GetValidInput(ValidationMessages.EnterReservationDate, ReservationValidator.ValidateReservationDate);
                var reservationDate = DateTime.Parse(reservationDateInput);

                var partySizeInput = InputHelper.GetValidInput(ValidationMessages.EnterPartySize, ReservationValidator.ValidatePartySize);
                var partySize = int.Parse(partySizeInput);

                reservation.ReservationDate = reservationDate;
                reservation.PartySize = partySize;

                _reservationRepo.Update(reservation);
                Console.WriteLine($"Reservation with ID {reservationId} updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating reservation: {ex.Message}");
            }
        }

        public void ListReservationsByCustomer()
        {
            Console.WriteLine();
            try
            {
                var customerId = InputHelper.GetValidCustomerId(_customerRepo);
                var customer = _customerRepo.GetById(customerId);

                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                var reservations = _reservationRepo.GetByCustomerId(customerId);
                if (reservations.Count == 0)
                {
                    Console.WriteLine($"No reservations found for customer {customer.FirstName} {customer.LastName}.");
                    return;
                }

                Console.WriteLine($"\nReservations for {customer.FirstName} {customer.LastName}:");

                foreach (var res in reservations)
                {
                    Console.WriteLine(res.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving reservations: {ex.Message}");
            }
        }

        public void ListOrdersAndMenuItems()
        {
            Console.WriteLine();
            try
            {
                var reservationId = InputHelper.GetValidReservationId(_reservationRepo);
                var orders = _reservationRepo.ListOrdersAndMenuItems(reservationId);

                if (!orders.Any())
                {
                    Console.WriteLine($"\nNo orders found for reservation {reservationId}.");
                    return;
                }

                Console.WriteLine($"\nOrders and Menu Items for Reservation {reservationId}:");

                foreach (var order in orders)
                {
                    Console.WriteLine($"\nOrder #{order.OrderId}:");
                    Console.WriteLine($"  Date: {order.OrderDate:yyyy-MM-dd HH:mm}");
                    Console.WriteLine($"  Total: {order.TotalAmount:C}");
                    Console.WriteLine("  Items:");
                    foreach (var orderItem in order.OrderItems)
                    {
                        Console.WriteLine($"    - {orderItem.MenuItem.Name} (Qty: {orderItem.Quantity})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving orders and menu items: {ex.Message}");
            }
        }

        public void ListOrderedMenuItems()
        {
            Console.WriteLine();
            try
            {
                var reservationId = InputHelper.GetValidReservationId(_reservationRepo);
                var menuItems = _reservationRepo.ListOrderedMenuItems(reservationId);

                if (!menuItems.Any())
                {
                    Console.WriteLine($"\nNo menu items found for reservation {reservationId}.");
                    return;
                }

                Console.WriteLine($"\nMenu Items for Reservation {reservationId}");

                foreach (var item in menuItems)
                {
                    Console.WriteLine($"    - {item}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving menu items: {ex.Message}");
            }
        }

        private bool IsEmpty()
        {
            return _reservationRepo.IsEmpty();
        }
    }
}
