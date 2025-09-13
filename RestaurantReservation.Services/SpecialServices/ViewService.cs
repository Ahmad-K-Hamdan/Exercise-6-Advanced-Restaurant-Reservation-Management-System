using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.SpecialServices
{
    public class ViewService
    {
        private readonly ViewRepository _viewRepository;

        public ViewService(ViewRepository viewsRepository)
        {
            _viewRepository = viewsRepository;
        }

        public void ViewAllReservationDetails()
        {
            Console.WriteLine();
            try
            {
                var reservationDetails = _viewRepository.GetReservationDetails();

                if (!reservationDetails.Any())
                {
                    Console.WriteLine("\nNo reservation details found.");
                }
                else
                {
                    Console.WriteLine("\nAll Reservation Details (From Database View):");
                    foreach (var reservation in reservationDetails)
                    {
                        Console.WriteLine(reservation.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving reservation details: {ex.Message}");
            }
        }

        public void ViewAllEmployeeDetails()
        {
            Console.WriteLine();
            try
            {
                var employeeDetails = _viewRepository.GetEmployeeDetails();

                if (!employeeDetails.Any())
                {
                    Console.WriteLine("\nNo employee details found.");
                }
                else
                {
                    Console.WriteLine("\nAll Employee Details (From Database View):");
                    foreach (var employee in employeeDetails)
                    {
                        Console.WriteLine(employee.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving employee details: {ex.Message}");
            }
        }
    }
}