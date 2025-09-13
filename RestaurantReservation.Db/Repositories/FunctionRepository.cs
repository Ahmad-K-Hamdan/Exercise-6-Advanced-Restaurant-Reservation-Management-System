using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories
{
    public class FunctionRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public FunctionRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public decimal GetRestaurantRevenue(int restaurantId)
        {
            try
            {
                var revenue = _context.Database
                    .SqlQuery<decimal>($"SELECT dbo.CalcTotalRevenue({restaurantId}) AS Value")
                    .FirstOrDefault();

                return revenue;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}