﻿namespace RestaurantReservation.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }
        public required DateTime OrderDate { get; set; }
        public required decimal TotalAmount { get; set; }

        public required Reservation Reservation { get; set; }
        public required Employee Employee { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public override string ToString()
        {
            return $"Order [ID: {OrderId} | Date: {OrderDate:g} | Total: {TotalAmount:C} | EmployeeID: {EmployeeId} | ReservationID: {ReservationId}]";
        }
    }
}
