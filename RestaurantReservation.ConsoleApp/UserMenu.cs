using RestaurantReservation.Services;

namespace RestaurantReservation.ConsoleApp
{
    public class UserMenu
    {
        public static void ShowMainMenu(AllServices allServices)
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
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewDataMenu(allServices);
                        break;
                    case "2":
                        //AddDataMenu();
                        break;
                    case "3":
                        //ManageDataMenu();
                        break;
                    case "4":
                        //DeleteDataMenu();
                        break;
                    case "5":
                        //SecondMenu();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ViewDataMenu(AllServices allServices)
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
                    allServices.RestaurantService.ViewAll();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
