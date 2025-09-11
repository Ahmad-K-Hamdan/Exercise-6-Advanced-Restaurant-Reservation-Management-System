using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

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
                var restaurantId = InputHelper.GetValidRestaurantId(_restaurantRepo);
                var restaurant = _restaurantRepo.GetById(restaurantId);

                var firstName = InputHelper.GetValidInput(ValidationMessages.EnterFirstName, EmployeeValidator.ValidateFirstName);
                var lastName = InputHelper.GetValidInput(ValidationMessages.EnterLastName, EmployeeValidator.ValidateLastName);
                var position = InputHelper.GetValidInput(ValidationMessages.EnterPosition, EmployeeValidator.ValidatePosition);

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

        public void Delete()
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

                _employeeRepo.Delete(employee);
                Console.WriteLine($"Employee with ID {employeeId} deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _employeeRepo.IsEmpty();
        }
    }
}
