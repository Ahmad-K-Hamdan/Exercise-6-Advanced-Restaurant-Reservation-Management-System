using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Core.DTOs;

namespace RestaurantReservation.Services.MainServices
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

        public List<Reservation> ViewAll()
        {
            return _reservationRepo.GetAll();
        }

        public Reservation Add(int customerId, int restaurantId, int tableId, DateTime reservationDate, int partySize)
        {
            var customer = GetCustomerById(customerId);
            var restaurant = GetRestaurantById(restaurantId);
            var table = GetTableById(tableId);

            var reservationDateValidation = ReservationValidator.ValidateReservationDate(reservationDate.ToString("yyyy-MM-dd HH:mm"));
            if (reservationDateValidation != null)
            {
                throw new ArgumentException(reservationDateValidation);
            }
            var partySizeValidation = ReservationValidator.ValidatePartySize(partySize.ToString());
            if (partySizeValidation != null)
            {
                throw new ArgumentException(partySizeValidation);
            }

            var newReservation = new Reservation
            {
                CustomerId = customerId,
                RestaurantId = restaurantId,
                TableId = tableId,
                ReservationDate = reservationDate,
                PartySize = partySize,
                Customer = customer,
                Restaurant = restaurant,
                Table = table
            };

            _reservationRepo.Add(newReservation);
            return newReservation;
        }

        public void Delete(int reservationId)
        {
            var reservation = GetReservationById(reservationId);
            _reservationRepo.Delete(reservation);
        }

        public Reservation Update(int reservationId, DateTime reservationDate, int partySize)
        {
            var reservation = GetReservationById(reservationId);

            var reservationDateValidation = ReservationValidator.ValidateReservationDate(reservationDate.ToString("yyyy-MM-dd HH:mm"));
            if (reservationDateValidation != null)
            {
                throw new ArgumentException(reservationDateValidation);
            }
            var partySizeValidation = ReservationValidator.ValidatePartySize(partySize.ToString());
            if (partySizeValidation != null)
            {
                throw new ArgumentException(partySizeValidation);
            }

            reservation.ReservationDate = reservationDate;
            reservation.PartySize = partySize;

            _reservationRepo.Update(reservation);
            return reservation;
        }

        public List<Reservation> ListReservationsByCustomer(int customerId)
        {
            return _reservationRepo.GetByCustomerId(customerId);
        }

        public List<Order> ListOrdersAndMenuItems(int reservationId)
        {
            return _reservationRepo.ListOrdersAndMenuItems(reservationId);
        }

        public List<OrderedMenuItemDTO> ListOrderedMenuItems(int reservationId)
        {
            return _reservationRepo.ListOrderedMenuItems(reservationId);
        }

        private Reservation GetReservationById(int reservationId)
        {
            var reservation = _reservationRepo.GetById(reservationId);
            if (reservation == null)
            {
                throw new InvalidOperationException($"Reservation with ID {reservationId} not found.");
            }
            return reservation;
        }

        private Customer GetCustomerById(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with ID {customerId} not found.");
            }
            return customer;
        }

        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _restaurantRepo.GetById(restaurantId);
            if (restaurant == null)
            {
                throw new InvalidOperationException($"Restaurant with ID {restaurantId} not found.");
            }
            return restaurant;
        }

        private Table GetTableById(int tableId)
        {
            var table = _tableRepo.GetById(tableId);
            if (table == null)
            {
                throw new InvalidOperationException($"Table with ID {tableId} not found.");
            }
            return table;
        }
    }
}