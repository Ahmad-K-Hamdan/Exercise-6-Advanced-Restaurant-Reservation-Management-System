using RestaurantReservation.Core.Constants;
using RestaurantReservation.Core.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

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
                var firstName = GetValidInput(ValidationMessages.EnterFirstName, CustomerValidator.ValidateFirstName);
                var lastName = GetValidInput(ValidationMessages.EnterLastName, CustomerValidator.ValidateLastName);
                var email = GetValidInput(ValidationMessages.EnterEmail, CustomerValidator.ValidateEmail);
                var phoneNumber = GetValidInput(ValidationMessages.EnterPhone, CustomerValidator.ValidatePhoneNumber);

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

        private string GetValidInput(string prompt, Func<string, string?> validator)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim()!;

                var errorMessage = validator(input);
                if (errorMessage == null)
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
