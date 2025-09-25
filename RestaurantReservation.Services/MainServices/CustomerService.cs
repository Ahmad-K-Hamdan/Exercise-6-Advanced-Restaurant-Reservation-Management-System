using RestaurantReservation.Core.Constants;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services.MainServices
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public List<Customer> ViewAll()
        {
            return _customerRepo.GetAll();
        }

        public Customer Add(string firstName, string lastName, string email, string phoneNumber)
        {
            var cusFirstName = CustomerValidator.ValidateFirstName(firstName);
            if (cusFirstName != null)
            {
                throw new ArgumentException(cusFirstName);
            }
            var cusLastName = CustomerValidator.ValidateLastName(lastName);
            if (cusLastName != null)
            {
                throw new ArgumentException(cusLastName);
            }
            var cusEmail = CustomerValidator.ValidateEmail(email);
            if (cusEmail != null)
            {
                throw new ArgumentException(cusEmail);
            }
            var cusPhoneNumber = CustomerValidator.ValidatePhoneNumber(phoneNumber);
            if (cusPhoneNumber != null)
            {
                throw new ArgumentException(cusPhoneNumber);
            }

            var newCustomer = new Customer
            {
                FirstName = cusFirstName!,
                LastName = cusLastName!,
                Email = cusEmail!,
                PhoneNumber = cusPhoneNumber!
            };

            _customerRepo.Add(newCustomer);
            return newCustomer;
        }

        public void Delete(int customerId)
        {
            var customer = GetCustomerById(customerId);
            _customerRepo.Delete(customer);
        }

        public Customer Update(int customerId, string firstName, string lastName, string email, string phoneNumber)
        {
            var customer = GetCustomerById(customerId);

            var cusFirstName = CustomerValidator.ValidateFirstName(firstName);
            if (cusFirstName != null)
            {
                throw new ArgumentException(cusFirstName);
            }
            var cusLastName = CustomerValidator.ValidateLastName(lastName);
            if (cusLastName != null)
            {
                throw new ArgumentException(cusLastName);
            }
            var cusEmail = CustomerValidator.ValidateEmail(email);
            if (cusEmail != null)
            {
                throw new ArgumentException(cusEmail);
            }
            var cusPhoneNumber = CustomerValidator.ValidatePhoneNumber(phoneNumber);
            if (cusPhoneNumber != null)
            {
                throw new ArgumentException(cusPhoneNumber);
            }

            customer.FirstName = cusFirstName!;
            customer.LastName = cusLastName!;
            customer.Email = cusEmail!;
            customer.PhoneNumber = cusPhoneNumber!;

            _customerRepo.Update(customer);
            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with ID {customerId} not found.");
            }
            return customer;
        }
    }
}
