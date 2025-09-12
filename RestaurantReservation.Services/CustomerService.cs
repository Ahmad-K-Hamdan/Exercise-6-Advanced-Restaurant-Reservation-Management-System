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

        public void Delete()
        {
            Console.WriteLine();
            try
            {
                var customerId = InputHelper.GetValidCustomerId(_customerRepo);
                var customer = _customerRepo.GetById(customerId);

                if (customer == null)
                {
                    Console.WriteLine($"Customer not found.");
                }
                else
                {
                    _customerRepo.Delete(customer);
                    Console.WriteLine($"Customer with ID {customerId} deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customer: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Update()
        {
            Console.WriteLine();
            try
            {
                var customerId = InputHelper.GetValidCustomerId(_customerRepo);
                var customer = _customerRepo.GetById(customerId);

                if (customer == null)
                {
                    Console.WriteLine($"Customer not found.");
                    return;
                }

                Console.WriteLine($"Managing Customer: {customer}");

                var firstName = InputHelper.GetValidInput(ValidationMessages.EnterFirstName, CustomerValidator.ValidateFirstName);
                var lastName = InputHelper.GetValidInput(ValidationMessages.EnterLastName, CustomerValidator.ValidateLastName);
                var email = InputHelper.GetValidInput(ValidationMessages.EnterEmail, CustomerValidator.ValidateEmail);
                var phoneNumber = InputHelper.GetValidInput(ValidationMessages.EnterPhone, CustomerValidator.ValidatePhoneNumber);

                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.Email = email;
                customer.PhoneNumber = phoneNumber;

                _customerRepo.Update(customer);
                Console.WriteLine($"Customer with ID {customerId} updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error managing customer: {ex.Message}");
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
