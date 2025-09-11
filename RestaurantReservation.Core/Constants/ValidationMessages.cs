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

        // Customer Messages - Prompts
        public const string EnterFirstName = "Enter first name: ";
        public const string EnterLastName = "Enter last name: ";
        public const string EnterEmail = "Enter email: ";
        public const string EnterCustomerPhone = "Enter phone number: ";

        // Customer Messages - Validation
        public const string NameTooShort = "Name must be at least 2 characters long.";
        public const string NameTooLong = "Name cannot exceed 50 characters.";
        public const string NameInvalidCharacters = "Name can only contain letters";
        public const string EmailInvalid = "Please enter a valid email address.";
    }
}
