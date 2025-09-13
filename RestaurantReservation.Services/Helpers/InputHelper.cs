using RestaurantReservation.Core.Constants;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.Helpers
{
    public static class InputHelper
    {
        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static string GetValidInput(string prompt, Func<string, string?> validator)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim()!;

                var errorMessage = validator(input);
                if (errorMessage == null)
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }

        public static int GetValidRestaurantId(RestaurantRepository restaurantRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterRestaurantId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var restaurant = restaurantRepo.GetById(id);
                    if (restaurant != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.RestaurantNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidCustomerId(CustomerRepository customerRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterCustomerId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var customer = customerRepo.GetById(id);
                    if (customer != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.CustomerNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidEmployeeId(EmployeeRepository employeeRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterEmployeeId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var employee = employeeRepo.GetById(id);
                    if (employee != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.EmployeeNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidTableId(TableRepository tableRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterTableId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var table = tableRepo.GetById(id);
                    if (table != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.TableNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidMenuItemId(MenuItemRepository menuItemRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterMenuItemId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var menuItem = menuItemRepo.GetById(id);
                    if (menuItem != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.MenuItemNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidOrderId(OrderRepository orderRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterOrderId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var order = orderRepo.GetById(id);
                    if (order != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.OrderNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidReservationId(ReservationRepository reservationRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterReservationId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var reservation = reservationRepo.GetById(id);
                    if (reservation != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.ReservationNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        public static int GetValidOrderItemId(OrderItemRepository orderItemRepo)
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterOrderItemId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var orderItem = orderItemRepo.GetById(id);
                    if (orderItem != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.OrderItemNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }
    }
}