using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Core.DTOs;

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

        public List<Employee> ViewAll()
        {
            return _employeeRepo.GetAll();
        }

        public Employee Add(int restaurantId, string firstName, string lastName, string position)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var empFirstName = EmployeeValidator.ValidateFirstName(firstName);
            if (empFirstName != null)
            {
                throw new ArgumentException(empFirstName);
            }
            var empLastName = EmployeeValidator.ValidateLastName(lastName);
            if (empLastName != null)
            {
                throw new ArgumentException(empLastName);
            }
            var empPosition = EmployeeValidator.ValidatePosition(position);
            if (empPosition != null)
            {
                throw new ArgumentException(empPosition);
            }

            var newEmployee = new Employee
            {
                RestaurantId = restaurantId,
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                Restaurant = restaurant
            };

            _employeeRepo.Add(newEmployee);
            return newEmployee;
        }

        public void Delete(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            _employeeRepo.Delete(employee);
        }

        public Employee Update(int employeeId, string firstName, string lastName, string position)
        {
            var employee = GetEmployeeById(employeeId);

            var empFirstName = EmployeeValidator.ValidateFirstName(firstName);
            if (empFirstName != null)
            {
                throw new ArgumentException(empFirstName);
            }
            var empLastName = EmployeeValidator.ValidateLastName(lastName);
            if (empLastName != null)
            {
                throw new ArgumentException(empLastName);
            }
            var empPosition = EmployeeValidator.ValidatePosition(position);
            if (empPosition != null)
            {
                throw new ArgumentException(empPosition);
            }

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Position = position;

            _employeeRepo.Update(employee);
            return employee;
        }

        public List<Employee> ListManagers()
        {
            return _employeeRepo.GetManagers();
        }

        public List<EmployeeDetailsDTO> GetEmployeeDetails()
        {
            return _employeeRepo.GetEmployeeDetails();
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

        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _restaurantRepo.GetById(restaurantId);
            if (restaurant == null)
            {
                throw new ArgumentException("Restaurant not found.");
            }
            return restaurant;
        }
    }
}
