using RestaurantReservation.Core.DTOs;

namespace RestaurantReservation.Db.Repositories
{
    public class ViewRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ViewRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<ReservationDetailsDTO> GetReservationDetails()
        {
            return _context.ReservationDetailsView.ToList();
        }

        public List<EmployeeDetailsDTO> GetEmployeeDetails()
        {
            return _context.EmployeeDetailsView.ToList();
        }
    }
}
