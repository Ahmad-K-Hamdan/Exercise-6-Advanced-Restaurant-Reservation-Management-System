using RestaurantReservation.Core.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> AddAsync(Employee employee);
        Task<Employee?> GetByIdAsync(int employeeId);
        Task<Employee> UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<List<Employee>> GetManagersAsync();
        Task<List<EmployeeDetailsDTO>> GetEmployeeDetailsAsync();
    }
}