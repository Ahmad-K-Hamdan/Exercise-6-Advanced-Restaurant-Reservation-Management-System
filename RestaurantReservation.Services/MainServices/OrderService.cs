using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

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

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo orders found.");
                return;
            }

            var orders = _orderRepo.GetAll();
            Console.WriteLine("\nAll Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var reservationId = InputHelper.GetValidReservationId(_reservationRepo);
                var reservation = _reservationRepo.GetById(reservationId);

                var employeeId = InputHelper.GetValidEmployeeId(_employeeRepo);
                var employee = _employeeRepo.GetById(employeeId);

                var orderDateInput = InputHelper.GetValidInput(ValidationMessages.EnterOrderDate, OrderValidator.ValidateOrderDate);
                var orderDate = DateTime.Parse(orderDateInput);

                var totalAmountInput = InputHelper.GetValidInput(ValidationMessages.EnterTotalAmount, OrderValidator.ValidateTotalAmount);
                var totalAmount = decimal.Parse(totalAmountInput);

                var newOrder = new Order
                {
                    ReservationId = reservationId,
                    EmployeeId = employeeId,
                    OrderDate = orderDate,
                    TotalAmount = totalAmount,
                    Reservation = reservation!,
                    Employee = employee!
                };

                _orderRepo.Add(newOrder);
                Console.WriteLine($"Order with total {totalAmount:C} added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order: {ex.Message}");
            }
        }

        public void Delete()
        {
            Console.WriteLine();
            try
            {
                var orderId = InputHelper.GetValidOrderId(_orderRepo);
                var order = _orderRepo.GetById(orderId);

                if (order == null)
                {
                    Console.WriteLine("Order not found.");
                }
                else
                {
                    _orderRepo.Delete(order);
                    Console.WriteLine($"Order with ID {orderId} deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order: {ex.Message}");
            }
        }

        public void Update()
        {
            Console.WriteLine();
            try
            {
                var orderId = InputHelper.GetValidOrderId(_orderRepo);
                var order = _orderRepo.GetById(orderId);

                if (order == null)
                {
                    Console.WriteLine($"Order with ID {orderId} not found.");
                    return;
                }

                Console.WriteLine($"Managing Order: {order}");

                var employeeId = InputHelper.GetValidEmployeeId(_employeeRepo);

                order.EmployeeId = employeeId;

                _orderRepo.Update(order);
                Console.WriteLine($"Order with ID {orderId} updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error managing order: {ex.Message}");
            }
        }

        public void CalculateAverageOrderAmountByEmployee()
        {
            Console.WriteLine();
            try
            {
                var employeeId = InputHelper.GetValidEmployeeId(_employeeRepo);
                var employee = _employeeRepo.GetById(employeeId);

                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                var averageOrderAmount = _orderRepo.CalculateAverageOrderAmountByEmployee(employeeId);

                if (averageOrderAmount == 0)
                {
                    Console.WriteLine($"No orders found for employee {employee.FirstName} {employee.LastName}.");
                    return;
                }

                Console.WriteLine($"Average order amount for employee {employee.FirstName} {employee.LastName} is {averageOrderAmount:C}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating average order amount: {ex.Message}");
            }
        }

        private bool IsEmpty()
        {
            return _orderRepo.IsEmpty();
        }
    }
}
