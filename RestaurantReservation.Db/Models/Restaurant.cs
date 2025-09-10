namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        public int RestaurantId;
        public required string Name;
        public required string Address;
        public required string PhoneNumber;
        public required TimeSpan OpeningHours;

        public List<Table> Tables { get; set; } = new List<Table>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
