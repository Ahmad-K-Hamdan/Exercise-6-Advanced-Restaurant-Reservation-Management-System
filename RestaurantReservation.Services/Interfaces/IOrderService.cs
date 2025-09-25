using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddAsync(int reservationId, int employeeId, DateTime orderDate, decimal totalAmount);
        Task<decimal> CalculateAverageOrderAmountByEmployeeAsync(int employeeId);
        Task DeleteAsync(int orderId);
        Task<Order> UpdateAsync(int orderId, int employeeId);
        Task<List<Order>> ViewAllAsync();
    }
}