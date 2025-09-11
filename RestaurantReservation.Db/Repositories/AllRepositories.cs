namespace RestaurantReservation.Db.Repositories
{
    public class AllRepositories
    {
        public RestaurantRepository RestaurantRepo { get; private set; }
        public ReservationRepository ReservationRepo { get; private set; }
        public OrderRepository OrderRepo { get; private set; }
        public CustomerRepository CustomerRepo { get; private set; }
        public TableRepository TableRepo { get; private set; }
        public MenuItemRepository MenuItemRepo { get; private set; }
        public EmployeeRepository EmployeeRepo { get; private set; }
        public OrderItemRepository OrderItemRepo { get; private set; }

        public AllRepositories(RestaurantReservationDbContext context)
        {
            RestaurantRepo = new RestaurantRepository(context);
            ReservationRepo = new ReservationRepository(context);
            OrderRepo = new OrderRepository(context);
            CustomerRepo = new CustomerRepository(context);
            TableRepo = new TableRepository(context);
            MenuItemRepo = new MenuItemRepository(context);
            EmployeeRepo = new EmployeeRepository(context);
            OrderItemRepo = new OrderItemRepository(context);
        }
    }
}