using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class OrderValidator
    {
        public static string? ValidateOrderDate(string orderDateInput)
        {
            if (string.IsNullOrWhiteSpace(orderDateInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!DateTime.TryParse(orderDateInput, out var orderDate))
            {
                return ValidationMessages.InvalidDate;
            }

            if (orderDate > DateTime.Now)
            {
                return ValidationMessages.DateCannotBeFuture;
            }

            if (orderDate < DateTime.Now.AddDays(-1))
            {
                return ValidationMessages.OrderDateTooOld;
            }

            return null;
        }

        public static string? ValidateTotalAmount(string totalAmountInput)
        {
            if (string.IsNullOrWhiteSpace(totalAmountInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!decimal.TryParse(totalAmountInput, out var totalAmount))
            {
                return ValidationMessages.InvalidNumber;
            }

            if (totalAmount <= 0)
            {
                return ValidationMessages.TotalAmountLessThanOrEqualToZero;
            }

            if (totalAmount > 10000)
            {
                return ValidationMessages.TotalAmountTooHigh;
            }

            return null;
        }
    }
}
