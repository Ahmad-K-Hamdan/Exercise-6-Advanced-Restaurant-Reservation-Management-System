using RestaurantReservation.Services.Helpers;
using RestaurantReservation.Services.MainServices;

namespace RestaurantReservation.ConsoleApp.Menus
{
    public class ViewDataMenu
    {
        private readonly RestaurantService _restaurantService;
        private readonly EmployeeService _employeeService;
        private readonly TableService _tableService;
        private readonly ReservationService _reservationService;
        private readonly MenuItemService _menuItemService;
        private readonly OrderService _orderService;
        private readonly OrderItemService _orderItemService;
        private readonly CustomerService _customerService;

        public ViewDataMenu(
            RestaurantService restaurantService,
            EmployeeService employeeService,
            TableService tableService,
            ReservationService reservationService,
            MenuItemService menuItemService,
            OrderService orderService,
            OrderItemService orderItemService,
            CustomerService customerService)
        {
            _restaurantService = restaurantService;
            _employeeService = employeeService;
            _tableService = tableService;
            _reservationService = reservationService;
            _menuItemService = menuItemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _customerService = customerService;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Which data would you like to view?");
            Console.WriteLine("1. Restaurants");
            Console.WriteLine("2. Employees");
            Console.WriteLine("3. Tables");
            Console.WriteLine("4. Reservations");
            Console.WriteLine("5. Menu Items");
            Console.WriteLine("6. Orders");
            Console.WriteLine("7. Order Items");
            Console.WriteLine("8. Customers");
            Console.WriteLine("9. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _restaurantService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "2":
                    _employeeService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "3":
                    _tableService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "4":
                    _reservationService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "5":
                    _menuItemService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "6":
                    _orderService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "7":
                    _orderItemService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "8":
                    _customerService.ViewAll();
                    InputHelper.Continue();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    InputHelper.Continue();
                    break;
            }
        }
    }
}