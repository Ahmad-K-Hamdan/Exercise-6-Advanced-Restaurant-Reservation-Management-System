using RestaurantReservation.Services.Helpers;
using RestaurantReservation.Services.MainServices;

namespace RestaurantReservation.ConsoleApp.Menus
{
    public class QueriesMenu
    {
        private readonly EmployeeService _employeeService;
        private readonly ReservationService _reservationService;
        private readonly OrderService _orderService;

        public QueriesMenu(
            EmployeeService employeeService,
            ReservationService reservationService,
            OrderService orderService)
        {
            _employeeService = employeeService;
            _reservationService = reservationService;
            _orderService = orderService;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. List all managers");
            Console.WriteLine("2. List all reservations for a customer");
            Console.WriteLine("3. List all orders for a reservation");
            Console.WriteLine("4. List all ordered items in a reservation");
            Console.WriteLine("5. Calculate average amount for an employee");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _employeeService.ListManagers();
                    InputHelper.Continue();
                    break;
                case "2":
                    _reservationService.ListReservationsByCustomer();
                    InputHelper.Continue();
                    break;
                case "3":
                    _reservationService.ListOrdersAndMenuItems();
                    InputHelper.Continue();
                    break;
                case "4":
                    _reservationService.ListOrderedMenuItems();
                    InputHelper.Continue();
                    break;
                case "5":
                    _orderService.CalculateAverageOrderAmountByEmployee();
                    InputHelper.Continue();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    InputHelper.Continue();
                    break;
            }
        }
    }
}