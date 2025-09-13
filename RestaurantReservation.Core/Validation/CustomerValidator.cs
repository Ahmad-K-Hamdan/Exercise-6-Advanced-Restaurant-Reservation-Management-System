using System.Text.RegularExpressions;
using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class CustomerValidator
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

            if (!Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
            {
                return ValidationMessages.NameInvalidCharacters;
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

            if (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$"))
            {
                return ValidationMessages.NameInvalidCharacters;
            }

            return null;
        }

        public static string? ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return ValidationMessages.EmailInvalid;
            }

            return null;
        }

        public static string? ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!Regex.IsMatch(phoneNumber, @"^\+?[1-9][0-9]{7,14}$"))
            {
                return ValidationMessages.PhoneInvalid;
            }

            return null;
        }
    }
}
