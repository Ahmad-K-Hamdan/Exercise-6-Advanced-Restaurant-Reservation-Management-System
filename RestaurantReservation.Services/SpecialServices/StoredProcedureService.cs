using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

namespace RestaurantReservation.Services.SpecialServices
{
    public class StoredProcedureService
    {
        private readonly StoredProcedureRepository _storedProcedureRepo;

        public StoredProcedureService(StoredProcedureRepository storedProcedureRepo)
        {
            _storedProcedureRepo = storedProcedureRepo;
        }

        public void ListAllCusWithMinPartySize()
        {
            Console.WriteLine();
            try
            {
                var partySizeInput = InputHelper.GetValidInput(ValidationMessages.EnterPartySize, ReservationValidator.ValidatePartySize);
                var partySize = int.Parse(partySizeInput);
                var customers = _storedProcedureRepo.FindCustomersByPartySize(partySize);

                if (customers.Count == 0)
                {
                    Console.WriteLine($"No reservations have a party size more than {partySize}.");
                    return;
                }

                Console.WriteLine($"\nCustomers with Reservations > {partySize} People");
                foreach (var customer in customers!)
                {
                    Console.WriteLine(customer.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding customers by party size: {ex.Message}");
            }
        }
    }
}

