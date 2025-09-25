using System.Threading.Tasks;
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

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> GetById(int EmployeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == EmployeeId);
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
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
