namespace RestaurantReservation.Services.DTOs;

public class OrderedMenuItemDTO
{
    public int MenuItemId { get; set; }
    public string? MenuItemName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public override string ToString()
    {
        return $"{MenuItemName} (Qty: {Quantity}) - {Price:C} each = {TotalPrice:C}";
    }
}
