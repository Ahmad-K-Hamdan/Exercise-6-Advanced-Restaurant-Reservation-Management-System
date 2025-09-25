using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.MainServices
{
    public class TableService
    {
        private readonly TableRepository _tableRepo;
        private readonly RestaurantRepository _restaurantRepo;

        public TableService(TableRepository tableRepo, RestaurantRepository restaurantRepo)
        {
            _tableRepo = tableRepo;
            _restaurantRepo = restaurantRepo;
        }

        public List<Table> ViewAll()
        {
            return _tableRepo.GetAll();
        }

        public Table Add(int restaurantId, int capacity)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var tableCapacity = TableValidator.ValidateCapacity(capacity.ToString());
            if (tableCapacity != null)
            {
                throw new ArgumentException(tableCapacity);
            }

            var newTable = new Table
            {
                RestaurantId = restaurantId,
                Capacity = capacity,
                Restaurant = restaurant
            };

            _tableRepo.Add(newTable);
            return newTable;
        }

        public void Delete(int tableId)
        {
            var table = GetTableById(tableId);
            _tableRepo.Delete(table);
        }

        public Table Update(int tableId, int restaurantId, int capacity)
        {
            var table = GetTableById(tableId);

            var tableCapacity = TableValidator.ValidateCapacity(capacity.ToString());
            if (tableCapacity != null)
            {
                throw new ArgumentException(tableCapacity);
            }

            table.RestaurantId = restaurantId;
            table.Capacity = capacity;

            _tableRepo.Update(table);
            return table;
        }

        private Table GetTableById(int tableId)
        {
            var table = _tableRepo.GetById(tableId);
            if (table == null)
            {
                throw new InvalidOperationException($"Table with ID {tableId} not found.");
            }
            return table;
        }

        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _restaurantRepo.GetById(restaurantId);
            if (restaurant == null)
            {
                throw new InvalidOperationException($"Restaurant with ID {restaurantId} not found.");
            }
            return restaurant;
        }
    }
}
