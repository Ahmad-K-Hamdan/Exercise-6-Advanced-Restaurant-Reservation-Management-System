using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Core.Constants
{
    public static class ValidationMessages
    {
        // Error messages
        public const string InputCannotBeEmpty = "Input cannot be empty. Please try again.";

        // Restaurant Messages
        // Restaurant Messages - Prompts
        public const string EnterRestaurantName = "Enter restaurant name: ";
        public const string EnterRestaurantAddress = "Enter restaurant address: ";
        public const string EnterRestaurantPhone = "Enter restaurant phone number: ";
        public const string EnterOpeningHours = "Enter opening hours (HH:mm): ";


        // Restaurant Messages - Validation
        public const string RestaurantNameTooShort = "Restaurant name must be at least 2 characters long.";
        public const string RestaurantNameTooLong = "Restaurant name cannot exceed 100 characters.";
        public const string AddressTooShort = "Restaurant Address must be at least 5 characters long.";
        public const string AddressTooLong = "Restaurant Address cannot exceed 200 characters.";
        public const string PhoneInvalid = "Please enter a valid phone number.";
        public const string TimeInvalid = "Please enter time in HH:mm format.";
        public const string TimeOutOfRange = "Time must be between 00:00 and 23:59.";
    }
}
