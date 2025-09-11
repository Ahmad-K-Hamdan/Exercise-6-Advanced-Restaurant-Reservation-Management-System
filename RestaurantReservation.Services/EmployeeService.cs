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
    }
}
