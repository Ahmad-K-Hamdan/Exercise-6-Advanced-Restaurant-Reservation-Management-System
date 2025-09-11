using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class EmployeeValidator
    {
        public static string? ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (firstName.Length < 2)
            {
                return ValidationMessages.NameTooShort;
            }

            if (firstName.Length > 50)
            {
                return ValidationMessages.NameTooLong;
            }

            return null;
        }

        public static string? ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (lastName.Length < 2)
            {
                return ValidationMessages.NameTooShort;
            }

            if (lastName.Length > 50)
            {
                return ValidationMessages.NameTooLong;
            }

            return null;
        }

        public static string? ValidatePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            var validPositions = new[] { "Manager", "Server", "Chef", "Host", "Bartender", "Cashier" };
            if (!validPositions.Contains(position, StringComparer.OrdinalIgnoreCase))
            {
                return ValidationMessages.PositionInvalid;
            }

            return null;
        }
    }
}
