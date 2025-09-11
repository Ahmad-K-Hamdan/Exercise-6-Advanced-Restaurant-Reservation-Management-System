using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class AllServices
    {
        public RestaurantService RestaurantService { get; private set; }
        public ReservationService ReservationService { get; private set; }
        public OrderService OrderService { get; private set; }
        public CustomerService CustomerService { get; private set; }
        public TableService TableService { get; private set; }
        public MenuItemService MenuItemService { get; private set; }
        public EmployeeService EmployeeService { get; private set; }
        public OrderItemService OrderItemService { get; private set; }

        public AllServices(AllRepositories repos)
        {
            RestaurantService = new RestaurantService(repos.RestaurantRepo);
            ReservationService = new ReservationService(repos.ReservationRepo);
            OrderService = new OrderService(repos.OrderRepo);
            CustomerService = new CustomerService(repos.CustomerRepo);
            TableService = new TableService(repos.TableRepo);
            MenuItemService = new MenuItemService(repos.MenuItemRepo);
            EmployeeService = new EmployeeService(repos.EmployeeRepo);
            OrderItemService = new OrderItemService(repos.OrderItemRepo);
        }
    }
}
