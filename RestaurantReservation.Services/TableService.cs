using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class TableService
    {
        private readonly TableRepository _tableRepo;

        public TableService(TableRepository tableRepo)
        {
            _tableRepo = tableRepo;
        }
    }
}
