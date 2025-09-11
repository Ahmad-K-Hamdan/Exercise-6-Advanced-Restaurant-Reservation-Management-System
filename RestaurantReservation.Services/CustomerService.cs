using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services.Helpers;

namespace RestaurantReservation.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public void ViewAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nNo customers found.");
                return;
            }

            var customers = _customerRepo.GetAll();
            Console.WriteLine("\nAll Customers:");
            foreach (var cust in customers)
            {
                Console.WriteLine(cust.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Add()
        {
            Console.WriteLine();
            try
            {
                var firstName = InputHelper.GetValidInput(ValidationMessages.EnterFirstName, CustomerValidator.ValidateFirstName);
                var lastName = InputHelper.GetValidInput(ValidationMessages.EnterLastName, CustomerValidator.ValidateLastName);
                var email = InputHelper.GetValidInput(ValidationMessages.EnterEmail, CustomerValidator.ValidateEmail);
                var phoneNumber = InputHelper.GetValidInput(ValidationMessages.EnterPhone, CustomerValidator.ValidatePhoneNumber);

                var newCustomer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };

                _customerRepo.Add(newCustomer);
                Console.WriteLine($"Customer '{firstName} {lastName}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding customer: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private bool IsEmpty()
        {
            return _customerRepo.IsEmpty();
        }
    }
}
