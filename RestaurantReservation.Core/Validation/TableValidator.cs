using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class TableValidator
    {
        public static string? ValidateCapacity(string capacityInput)
        {
            if (string.IsNullOrWhiteSpace(capacityInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!int.TryParse(capacityInput, out var capacity))
            {
                return ValidationMessages.InvalidNumber;
            }

            if (capacity < 1)
            {
                return ValidationMessages.CapacityLessThanOne;
            }

            if (capacity > 50)
            {
                return ValidationMessages.CapacityTooHigh;
            }

            return null;
        }
    }
}
