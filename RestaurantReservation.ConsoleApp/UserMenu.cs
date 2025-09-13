using RestaurantReservation.Services;
using RestaurantReservation.Services.Helpers;
using RestaurantReservation.Services.MainServices;

namespace RestaurantReservation.ConsoleApp
{
    public class UserMenu
    {
        private readonly RestaurantService _restaurantService;
        private readonly EmployeeService _employeeService;
        private readonly TableService _tableService;
        private readonly ReservationService _reservationService;
        private readonly MenuItemService _menuItemService;
        private readonly OrderService _orderService;
        private readonly OrderItemService _orderItemService;
        private readonly CustomerService _customerService;
        private readonly ViewService _viewService;
        private readonly FunctionService _functionService;

        public UserMenu(
            RestaurantService restaurantService,
            EmployeeService employeeService,
            TableService tableService,
            ReservationService reservationService,
            MenuItemService menuItemService,
            OrderService orderService,
            OrderItemService orderItemService,
            CustomerService customerService,
            ViewService viewService,
            FunctionService functionService)
        {
            _restaurantService = restaurantService;
            _employeeService = employeeService;
            _tableService = tableService;
            _reservationService = reservationService;
            _menuItemService = menuItemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _customerService = customerService;
            _viewService = viewService;
            _functionService = functionService;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Restaurant Reservation System");
                Console.WriteLine("1. View Data");
                Console.WriteLine("2. Add Data");
                Console.WriteLine("3. Manage Data");
                Console.WriteLine("4. Delete Data");
                Console.WriteLine("5. Second Menu");
                Console.WriteLine("6. Third Menu");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewDataMenu();
                        break;
                    case "2":
                        AddDataMenu();
                        break;
                    case "3":
                        ManageDataMenu();
                        break;
                    case "4":
                        DeleteDataMenu();
                        break;
                    case "5":
                        SecondMenu();
                        break;
                    case "6":
                        ThirdMenu();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        InputHelper.Continue();
                        break;
                }
            }
        }

        private void ViewDataMenu()
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

        private void AddDataMenu()
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

        private void DeleteDataMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to delete?");
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
                    _restaurantService.Delete();
                    InputHelper.Continue();
                    break;
                case "2":
                    _employeeService.Delete();
                    InputHelper.Continue();
                    break;
                case "3":
                    _tableService.Delete();
                    InputHelper.Continue();
                    break;
                case "4":
                    _customerService.Delete();
                    InputHelper.Continue();
                    break;
                case "5":
                    _menuItemService.Delete();
                    InputHelper.Continue();
                    break;
                case "6":
                    _reservationService.Delete();
                    InputHelper.Continue();
                    break;
                case "7":
                    _orderService.Delete();
                    InputHelper.Continue();
                    break;
                case "8":
                    _orderItemService.Delete();
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

        private void ManageDataMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to manage?");
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
                    _restaurantService.Update();
                    InputHelper.Continue();
                    break;
                case "2":
                    _employeeService.Update();
                    InputHelper.Continue();
                    break;
                case "3":
                    _tableService.Update();
                    InputHelper.Continue();
                    break;
                case "4":
                    _customerService.Update();
                    InputHelper.Continue();
                    break;
                case "5":
                    _menuItemService.Update();
                    InputHelper.Continue();
                    break;
                case "6":
                    _reservationService.Update();
                    InputHelper.Continue();
                    break;
                case "7":
                    _orderService.Update();
                    InputHelper.Continue();
                    break;
                case "8":
                    _orderItemService.Update();
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

        private void SecondMenu()
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

        private void ThirdMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Views - All reservations with restaurant and customer details");
            Console.WriteLine("2. Views - All employees with their respective restaurant details");
            Console.WriteLine("3. Functions - Calculate the total revenue generated by a specific restaurant");
            Console.WriteLine("4. Procedures - List all customers who have made reservations with a party size greater than a certain value");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _viewService.ViewAllReservationDetails();
                    InputHelper.Continue();
                    break;
                case "2":
                    _viewService.ViewAllEmployeeDetails();
                    InputHelper.Continue();
                    break;
                case "3":
                    _functionService.CalculateRestaurantRevenue();
                    InputHelper.Continue();
                    break;
                case "4":
                    InputHelper.Continue();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    InputHelper.Continue();
                    break;
            }
        }
    }
}
