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

        private bool IsEmpty()
        {
            return _tableRepo.IsEmpty();
        }
    }
}
