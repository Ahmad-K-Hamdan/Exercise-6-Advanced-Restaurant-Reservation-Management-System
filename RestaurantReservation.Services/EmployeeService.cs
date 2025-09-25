﻿using RestaurantReservation.Db.Models;
using RestaurantReservation.Core.Validation;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Core.DTOs;

namespace RestaurantReservation.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly RestaurantRepository _restaurantRepo;

        public EmployeeService(EmployeeRepository employeeRepo, RestaurantRepository restaurantRepo)
        {
            _employeeRepo = employeeRepo;
            _restaurantRepo = restaurantRepo;
        }

        public async Task<List<Employee>> ViewAllAsync()
        {
            return await _employeeRepo.GetAllAsync();
        }

        public async Task<Employee> AddAsync(int restaurantId, string firstName, string lastName, string position)
        {
            var restaurant = await GetRestaurantByIdAsync(restaurantId);

            var empFirstName = EmployeeValidator.ValidateFirstName(firstName);
            if (empFirstName != null)
            {
                throw new ArgumentException(empFirstName);
            }
            var empLastName = EmployeeValidator.ValidateLastName(lastName);
            if (empLastName != null)
            {
                throw new ArgumentException(empLastName);
            }
            var empPosition = EmployeeValidator.ValidatePosition(position);
            if (empPosition != null)
            {
                throw new ArgumentException(empPosition);
            }

            var newEmployee = new Employee
            {
                RestaurantId = restaurantId,
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                Restaurant = restaurant
            };

            return await _employeeRepo.AddAsync(newEmployee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);
            await _employeeRepo.DeleteAsync(employee);
        }

        public async Task<Employee> UpdateAsync(int employeeId, string firstName, string lastName, string position)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);

            var empFirstName = EmployeeValidator.ValidateFirstName(firstName);
            if (empFirstName != null)
            {
                throw new ArgumentException(empFirstName);
            }
            var empLastName = EmployeeValidator.ValidateLastName(lastName);
            if (empLastName != null)
            {
                throw new ArgumentException(empLastName);
            }
            var empPosition = EmployeeValidator.ValidatePosition(position);
            if (empPosition != null)
            {
                throw new ArgumentException(empPosition);
            }

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Position = position;

            return await _employeeRepo.UpdateAsync(employee);
        }

        public async Task<List<Employee>> ListManagersAsync()
        {
            return await _employeeRepo.GetManagers();
        }

        public async Task<List<EmployeeDetailsDTO>> GetEmployeeDetailsAsync()
        {
            return await _employeeRepo.GetEmployeeDetails();
        }

        private async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepo.GetByIdAsync(employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with ID {employeeId} not found.");
            }
            return employee;
        }

        private async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepo.GetByIdAsync(restaurantId);
            if (restaurant == null)
            {
                throw new ArgumentException("Restaurant not found.");
            }
            return restaurant;
        }
    }
}
