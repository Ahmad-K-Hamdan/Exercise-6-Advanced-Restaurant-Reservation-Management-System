namespace RestaurantReservation.Core.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Position { get; set; }

        public required Restaurant Restaurant { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
