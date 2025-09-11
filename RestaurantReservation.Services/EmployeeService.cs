using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepo;

        public EmployeeService(EmployeeRepository EmployeeRepo)
        {
            _employeeRepo = EmployeeRepo;
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

        private bool IsEmpty()
        {
            return _employeeRepo.IsEmpty();
        }
    }
}
