using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

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

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo tables found.");
                return;
            }

            var tables = _tableRepo.GetAll();
            Console.WriteLine("\nAll Tables:");
            foreach (var tbl in tables)
            {
                Console.WriteLine(tbl.ToString());
            }
        }

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var restaurantId = InputHelper.GetValidRestaurantId(_restaurantRepo);
                var restaurant = _restaurantRepo.GetById(restaurantId);

                var capacityInput = InputHelper.GetValidInput(ValidationMessages.EnterTableCapacity, TableValidator.ValidateCapacity);
                var capacity = int.Parse(capacityInput);

                var newTable = new Table
                {
                    RestaurantId = restaurantId,
                    Capacity = capacity,
                    Restaurant = restaurant!
                };

                _tableRepo.Add(newTable);
                Console.WriteLine($"Table with capacity {capacity} added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding table: {ex.Message}");
            }
        }

        public void Delete()
        {
            Console.WriteLine();
            try
            {
                var tableId = InputHelper.GetValidTableId(_tableRepo);
                var table = _tableRepo.GetById(tableId);
                if (table == null)
                {
                    Console.WriteLine("Table not found.");
                }
                else
                {
                    _tableRepo.Delete(table);
                    Console.WriteLine($"Table with ID {tableId} deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting table: {ex.Message}");
            }
        }

        public void Update()
        {
            Console.WriteLine();
            try
            {
                var tableId = InputHelper.GetValidTableId(_tableRepo);
                var table = _tableRepo.GetById(tableId);

                if (table == null)
                {
                    Console.WriteLine($"Table with ID {tableId} not found.");
                    return;
                }

                Console.WriteLine($"Managing Table: {table}");

                var restaurantId = InputHelper.GetValidRestaurantId(_restaurantRepo);
                var capacityInput = InputHelper.GetValidInput(ValidationMessages.EnterTableCapacity, TableValidator.ValidateCapacity);
                var capacity = int.Parse(capacityInput);

                table.RestaurantId = restaurantId;
                table.Capacity = capacity;

                _tableRepo.Update(table);
                Console.WriteLine($"Table with ID {tableId} updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating table: {ex.Message}");
            }
        }

        private bool IsEmpty()
        {
            return _tableRepo.IsEmpty();
        }
    }
}
