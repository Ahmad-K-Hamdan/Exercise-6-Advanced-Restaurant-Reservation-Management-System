namespace RestaurantReservation.Db.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public required int Quantity { get; set; }

        public required Order Order { get; set; }
        public required MenuItem MenuItem { get; set; }
    }
}
