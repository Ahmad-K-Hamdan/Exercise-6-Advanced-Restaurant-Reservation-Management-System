namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
    }
}
