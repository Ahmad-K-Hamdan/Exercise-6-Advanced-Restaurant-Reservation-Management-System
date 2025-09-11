using RestaurantReservation.Core.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee? GetById(int EmployeeId)
        {
            return _context.Employees.FirstOrDefault(emp => emp.EmployeeId == EmployeeId);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public bool IsEmpty()
        {
            return !_context.Employees.Any();
        }
    }
}
