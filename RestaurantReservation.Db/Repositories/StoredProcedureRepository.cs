using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Core.DTOs;

namespace RestaurantReservation.Db.Repositories
{
    public class StoredProcedureRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public StoredProcedureRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public List<CustomerDetailsDTO> FindCustomersByPartySize(int minPartySize)
        {
            try
            {
                var customers = _context.Database
                    .SqlQuery<CustomerDetailsDTO>(
                        $"EXEC ListAllCusWithMinPartySize @MinPartySize = {minPartySize}"
                    ).ToList();

                return customers;
            }
            catch (Exception)
            {
                return new List<CustomerDetailsDTO>();
            }
        }
    }
}
