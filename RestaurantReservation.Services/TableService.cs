using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var restaurantId = GetValidRestaurantId();
                var restaurant = _restaurantRepo.GetById(restaurantId);

                var capacityInput = GetValidInput(ValidationMessages.EnterTableCapacity, TableValidator.ValidateCapacity);
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

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _tableRepo.IsEmpty();
        }

        private int GetValidRestaurantId()
        {
            while (true)
            {
                Console.Write(ValidationMessages.EnterRestaurantId);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var restaurant = _restaurantRepo.GetById(id);
                    if (restaurant != null)
                    {
                        return id;
                    }
                    Console.WriteLine(ValidationMessages.RestaurantNotFound);
                }
                else
                {
                    Console.WriteLine(ValidationMessages.InvalidNumber);
                }
            }
        }

        private string GetValidInput(string prompt, Func<string, string?> validator)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim()!;

                var errorMessage = validator(input);
                if (errorMessage == null)
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
