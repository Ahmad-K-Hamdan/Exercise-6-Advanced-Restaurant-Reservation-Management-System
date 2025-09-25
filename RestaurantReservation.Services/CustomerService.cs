﻿using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Core.DTOs;

namespace RestaurantReservation.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<Customer>> ViewAllAsync()
        {
            return await _customerRepo.GetAllAsync();
        }

        public async Task<Customer> AddAsync(string firstName, string lastName, string email, string phoneNumber)
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
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            return await _customerRepo.AddAsync(newCustomer);
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await GetCustomerByIdAsync(customerId);
            await _customerRepo.DeleteAsync(customer);
        }

        public async Task<Customer> UpdateAsync(int customerId, string firstName, string lastName, string email, string phoneNumber)
        {
            var customer = await GetCustomerByIdAsync(customerId);

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

            return await _customerRepo.UpdateAsync(customer);
        }

        public async Task<List<CustomerDetailsDTO>> FindCustomersByPartySizeAsync(int minPartySize)
        {
            var partySizeValidation = ReservationValidator.ValidatePartySize(minPartySize.ToString());
            if (partySizeValidation != null)
            {
                throw new ArgumentException(partySizeValidation);
            }
            return await _customerRepo.FindCustomersByPartySizeAsync(minPartySize);
        }

        private async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with ID {customerId} not found.");
            }
            return customer;
        }
    }
}
