using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Core.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
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

        public List<Employee> GetManagers()
        {
            return _context.Employees.Where(emp => emp.Position == "Manager").ToList();
        }

        public List<EmployeeDetailsDTO> GetEmployeeDetails()
        {
            return _context.EmployeeDetailsView.ToList();
        }
    }
}
