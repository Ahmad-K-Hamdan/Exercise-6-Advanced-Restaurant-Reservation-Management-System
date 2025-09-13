using RestaurantReservation.Services.Helpers;

namespace RestaurantReservation.ConsoleApp.Menus
{
    public class MainMenu
    {
        private readonly ViewDataMenu _viewDataMenu;
        private readonly AddDataMenu _addDataMenu;
        private readonly ManageDataMenu _manageDataMenu;
        private readonly DeleteDataMenu _deleteDataMenu;
        private readonly QueriesMenu _queriesMenu;
        private readonly DatabaseFeaturesMenu _databaseFeaturesMenu;

        public MainMenu(
            ViewDataMenu viewDataMenu,
            AddDataMenu addDataMenu,
            ManageDataMenu manageDataMenu,
            DeleteDataMenu deleteDataMenu,
            QueriesMenu queriesMenu,
            DatabaseFeaturesMenu databaseFeaturesMenu)
        {
            _viewDataMenu = viewDataMenu;
            _addDataMenu = addDataMenu;
            _manageDataMenu = manageDataMenu;
            _deleteDataMenu = deleteDataMenu;
            _queriesMenu = queriesMenu;
            _databaseFeaturesMenu = databaseFeaturesMenu;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Restaurant Reservation System");
                Console.WriteLine("1. View Data");
                Console.WriteLine("2. Add Data");
                Console.WriteLine("3. Manage Data");
                Console.WriteLine("4. Delete Data");
                Console.WriteLine("5. Queries Menu");
                Console.WriteLine("6. Database Features");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _viewDataMenu.Show();
                        break;
                    case "2":
                        _addDataMenu.Show();
                        break;
                    case "3":
                        _manageDataMenu.Show();
                        break;
                    case "4":
                        _deleteDataMenu.Show();
                        break;
                    case "5":
                        _queriesMenu.Show();
                        break;
                    case "6":
                        _databaseFeaturesMenu.Show();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        InputHelper.Continue();
                        break;
                }
            }
        }
    }
}