using RestaurantReservation.Core.Constants;

namespace RestaurantReservation.Core.Validation
{
    public static class ReservationValidator
    {
        public static string? ValidateReservationDate(string reservationDateInput)
        {
            if (string.IsNullOrWhiteSpace(reservationDateInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!DateTime.TryParse(reservationDateInput, out var reservationDate))
            {
                return ValidationMessages.InvalidDate;
            }

            if (reservationDate < DateTime.Now)
            {
                return ValidationMessages.DateCannotBePast;
            }

            if (reservationDate > DateTime.Now.AddYears(1))
            {
                return ValidationMessages.ReservationDateTooFar;
            }

            return null;
        }

        public static string? ValidatePartySize(string partySizeInput)
        {
            if (string.IsNullOrWhiteSpace(partySizeInput))
            {
                return ValidationMessages.InputCannotBeEmpty;
            }

            if (!int.TryParse(partySizeInput, out var partySize))
            {
                return ValidationMessages.InvalidNumber;
            }

            if (partySize <= 0)
            {
                return ValidationMessages.PartySizeLessThanOrEqualToZero;
            }

            if (partySize > 100)
            {
                return ValidationMessages.PartySizeTooHigh;
            }

            return null;
        }
    }
}
