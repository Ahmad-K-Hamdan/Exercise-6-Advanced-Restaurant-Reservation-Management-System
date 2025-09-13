using RestaurantReservation.Services.Helpers;
using RestaurantReservation.Services.MainServices;

namespace RestaurantReservation.ConsoleApp.Menus
{
    public class AddDataMenu
    {
        private readonly RestaurantService _restaurantService;
        private readonly EmployeeService _employeeService;
        private readonly TableService _tableService;
        private readonly ReservationService _reservationService;
        private readonly MenuItemService _menuItemService;
        private readonly OrderService _orderService;
        private readonly OrderItemService _orderItemService;
        private readonly CustomerService _customerService;

        public AddDataMenu(
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
            Console.WriteLine("What would you like to add?");
            Console.WriteLine("1. Restaurant");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Table");
            Console.WriteLine("4. Customer");
            Console.WriteLine("5. Menu Item");
            Console.WriteLine("6. Reservation");
            Console.WriteLine("7. Order");
            Console.WriteLine("8. Order Item");
            Console.WriteLine("9. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _restaurantService.Add();
                    InputHelper.Continue();
                    break;
                case "2":
                    _employeeService.Add();
                    InputHelper.Continue();
                    break;
                case "3":
                    _tableService.Add();
                    InputHelper.Continue();
                    break;
                case "4":
                    _customerService.Add();
                    InputHelper.Continue();
                    break;
                case "5":
                    _menuItemService.Add();
                    InputHelper.Continue();
                    break;
                case "6":
                    _reservationService.Add();
                    InputHelper.Continue();
                    break;
                case "7":
                    _orderService.Add();
                    InputHelper.Continue();
                    break;
                case "8":
                    _orderItemService.Add();
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