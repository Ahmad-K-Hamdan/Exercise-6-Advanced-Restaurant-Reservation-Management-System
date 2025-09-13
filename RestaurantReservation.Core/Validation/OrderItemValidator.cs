using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class OrderItemValidator
    {
        public static string? ValidateQuantity(string quantityInput)
        {
            if (string.IsNullOrWhiteSpace(quantityInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!int.TryParse(quantityInput, out var quantity))
            {
                return ValidationMessages.InvalidNumber;
            }

            if (quantity <= 0)
            {
                return ValidationMessages.QuantityLessThanOrEqualToZero;
            }

            if (quantity > 100)
            {
                return ValidationMessages.QuantityTooHigh;
            }

            return null;
        }
    }
}
