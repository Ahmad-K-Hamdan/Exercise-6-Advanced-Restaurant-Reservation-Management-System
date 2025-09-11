namespace RestaurantReservation.Core.Constants
{
    public static class ValidationMessages
    {
        // Error messages
        public const string InputCannotBeEmpty = "Input cannot be empty. Please try again.";
        public const string InvalidNumber = "Please enter a valid number.";
        public const string InvalidDate = "Please enter a valid date in yyyy-mm-dd hh:mm format.";
        public const string NameTooShort = "Name must be at least 2 characters long.";
        public const string NameTooLong = "Name cannot exceed 50 characters.";
        public const string NameInvalidCharacters = "Name can only contain letters.";
        public const string AddressTooShort = "Address must be at least 5 characters long.";
        public const string AddressTooLong = "Address cannot exceed 200 characters.";
        public const string PhoneInvalid = "Please enter a valid phone number.";
        public const string EmailInvalid = "Please enter a valid email address.";
        public const string TimeInvalid = "Please enter time in HH:mm format.";
        public const string TimeOutOfRange = "Time must be between 00:00 and 23:59.";
        public const string DateCannotBePast = "Date cannot be in the past.";
        public const string DateCannotBeFuture = "Date cannot be in the future.";
        public const string ReservationDateTooFar = "Reservation date cannot be more than 1 year in the future.";
        public const string DateTooFar = "Date cannot be more than 1 year in the future.";
        public const string DateTooOld = "Date cannot be more than 1 year old.";
        public const string CapacityLessThanOne = "Capacity must be at least 1.";
        public const string CapacityTooHigh = "Capacity cannot exceed 50.";
        public const string QuantityTooHigh = "Quantity cannot exceed 100.";
        public const string QuantityLessThanOrEqualToZero = "Quantity must be greater than 0.";
        public const string OrderDateTooOld = "Order date cannot be more than 1 day old.";
        public const string PartySizeLessThanOrEqualToZero = "Party size must be greater than 0.";
        public const string PartySizeTooHigh = "Party size cannot exceed 100.";
        public const string PriceTooHigh = "Price cannot exceed 1000.";
        public const string PriceLessThanOrEqualToZero = "Price must be greater than 0.";
        public const string TotalAmountTooHigh = "Total amount cannot exceed 10000.";
        public const string TotalAmountLessThanOrEqualToZero = "Total amount must be greater than 0.";
        public const string DescriptionTooShort = "Description must be at least 10 characters long.";
        public const string DescriptionTooLong = "Description cannot exceed 500 characters.";
        public const string PositionInvalid = "Position must be one of: Manager, Server, Chef, Host, Bartender, Cashier.";


        // Prompts
        public const string EnterFirstName = "Enter first name: ";
        public const string EnterLastName = "Enter last name: ";
        public const string EnterEmail = "Enter email: ";
        public const string EnterPhone = "Enter phone number: ";
        public const string EnterRestaurantName = "Enter restaurant name: ";
        public const string EnterRestaurantAddress = "Enter restaurant address: ";
        public const string EnterOpeningHours = "Enter opening hours (HH:mm): ";
        public const string EnterPosition = "Enter position: ";
        public const string EnterRestaurantId = "Enter restaurant ID: ";
        public const string EnterCustomerId = "Enter customer ID: ";
        public const string EnterEmployeeId = "Enter employee ID: ";
        public const string EnterTableId = "Enter table ID: ";
        public const string EnterMenuItemId = "Enter menu item ID: ";
        public const string EnterOrderId = "Enter order ID: ";
        public const string EnterOrderItemId = "Enter order item ID: ";
        public const string EnterReservationId = "Enter reservation ID: ";
        public const string EnterTableCapacity = "Enter table capacity: ";
        public const string EnterMenuItemName = "Enter menu item name: ";
        public const string EnterDescription = "Enter description: ";
        public const string EnterPrice = "Enter price: ";
        public const string EnterReservationDate = "Enter reservation date (yyyy-mm-dd hh:mm): ";
        public const string EnterPartySize = "Enter party size: ";
        public const string EnterOrderDate = "Enter order date (yyyy-mm-dd hh:mm): ";
        public const string EnterTotalAmount = "Enter total amount: ";
        public const string EnterQuantity = "Enter quantity: ";

        // Entity not found
        public const string RestaurantNotFound = "Restaurant not found. Please enter a valid restaurant ID.";
        public const string CustomerNotFound = "Customer not found. Please enter a valid customer ID.";
        public const string EmployeeNotFound = "Employee not found. Please enter a valid employee ID.";
        public const string TableNotFound = "Table not found. Please enter a valid table ID.";
        public const string MenuItemNotFound = "Menu item not found. Please enter a valid menu item ID.";
        public const string OrderNotFound = "Order not found. Please enter a valid order ID.";
        public const string OrderItemNotFound = "Order item not found. Please enter a valid order item ID.";
        public const string ReservationNotFound = "Reservation not found. Please enter a valid reservation ID.";
    }
}
