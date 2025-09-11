using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly RestaurantRepository _restaurantRepo;

        public EmployeeService(EmployeeRepository employeeRepo, RestaurantRepository restaurantRepo)
        {
            _employeeRepo = employeeRepo;
            _restaurantRepo = restaurantRepo;
        }

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo employees found.");
                return;
            }

            var employees = _employeeRepo.GetAll();
            Console.WriteLine("\nAll Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var restaurantId = GetValidRestaurantId();
                var restaurant = _restaurantRepo.GetById(restaurantId);

                var firstName = GetValidInput(ValidationMessages.EnterFirstName, EmployeeValidator.ValidateFirstName);
                var lastName = GetValidInput(ValidationMessages.EnterLastName, EmployeeValidator.ValidateLastName);
                var position = GetValidInput(ValidationMessages.EnterPosition, EmployeeValidator.ValidatePosition);

                var newEmployee = new Employee
                {
                    RestaurantId = restaurantId,
                    FirstName = firstName,
                    LastName = lastName,
                    Position = position,
                    Restaurant = restaurant!
                };

                _employeeRepo.Add(newEmployee);
                Console.WriteLine($"Employee '{firstName} {lastName}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _employeeRepo.IsEmpty();
        }

        private int GetValidRestaurantId()
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterRestaurantId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var restaurant = _restaurantRepo.GetById(id);
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

        private string GetValidInput(string prompt, Func<string, string?> validator)
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
    }
}
