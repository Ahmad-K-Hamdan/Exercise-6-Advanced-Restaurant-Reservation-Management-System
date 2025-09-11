namespace RestaurantReservation.Core.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int TableId { get; set; }
        public required DateTime ReservationDate { get; set; }
        public required int PartySize { get; set; }

        public required Customer Customer { get; set; }
        public required Restaurant Restaurant { get; set; }
        public required Table Table { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
