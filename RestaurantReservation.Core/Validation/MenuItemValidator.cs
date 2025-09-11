using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class MenuItemValidator
    {
        public static string? ValidateMenuItemName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (name.Length < 2)
            {
                return ValidationMessages.NameTooShort;
            }

            if (name.Length > 50)
            {
                return ValidationMessages.NameTooLong;
            }

            return null;
        }

        public static string? ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (description.Length < 10)
            {
                return ValidationMessages.DescriptionTooShort;
            }

            if (description.Length > 500)
            {
                return ValidationMessages.DescriptionTooLong;
            }

            return null;
        }

        public static string? ValidatePrice(string priceInput)
        {
            if (string.IsNullOrWhiteSpace(priceInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!decimal.TryParse(priceInput, out var price))
            {
                return ValidationMessages.InvalidNumber;
            }

            if (price <= 0)
            {
                return ValidationMessages.PriceLessThanOrEqualToZero;
            }

            if (price > 1000)
            {
                return ValidationMessages.PriceTooHigh;
            }

            return null;
        }
    }
}
