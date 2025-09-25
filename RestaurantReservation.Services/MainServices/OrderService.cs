using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.MainServices
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo;
        private readonly ReservationRepository _reservationRepo;
        private readonly EmployeeRepository _employeeRepo;

        public OrderService(OrderRepository orderRepo, ReservationRepository reservationRepo, EmployeeRepository employeeRepo)
        {
            _orderRepo = orderRepo;
            _reservationRepo = reservationRepo;
            _employeeRepo = employeeRepo;
        }

        public List<Order> ViewAll()
        {
            return _orderRepo.GetAll();
        }

        public Order Add(int reservationId, int employeeId, DateTime orderDate, decimal totalAmount)
        {
            var reservation = GetReservationById(reservationId);
            var employee = GetEmployeeById(employeeId);

            var orderDateValidation = OrderValidator.ValidateOrderDate(orderDate.ToString("yyyy-MM-dd HH:mm"));
            if (orderDateValidation != null)
            {
                throw new ArgumentException(orderDateValidation);
            }
            var totalAmountValidation = OrderValidator.ValidateTotalAmount(totalAmount.ToString());
            if (totalAmountValidation != null)
            {
                throw new ArgumentException(totalAmountValidation);
            }

            var newOrder = new Order
            {
                ReservationId = reservationId,
                EmployeeId = employeeId,
                OrderDate = orderDate,
                TotalAmount = totalAmount,
                Reservation = reservation,
                Employee = employee
            };

            _orderRepo.Add(newOrder);
            return newOrder;
        }

        public void Delete(int orderId)
        {
            var order = GetOrderById(orderId);
            _orderRepo.Delete(order);
        }

        public Order Update(int orderId, int employeeId)
        {
            var order = GetOrderById(orderId);
            order.EmployeeId = employeeId;
            _orderRepo.Update(order);
            return order;
        }

        public decimal CalculateAverageOrderAmountByEmployee(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            return _orderRepo.CalculateAverageOrderAmountByEmployee(employeeId);
        }

        private Order GetOrderById(int orderId)
        {
            var order = _orderRepo.GetById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} not found.");
            }
            return order;
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

        private Employee GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepo.GetById(employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with ID {employeeId} not found.");
            }
            return employee;
        }
    }
}