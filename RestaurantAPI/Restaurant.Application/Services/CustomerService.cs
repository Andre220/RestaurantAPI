using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.Repositories;
using Restaurant.Repository.Repositories.Interfaces;
using Restaurant.Shared.DTOs.Common;
using Restaurant.Shared.DTOs.Customers;

namespace Restaurant.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDto>> ListAllAsync()
        {
            var customers = await _repository.ListAllAsync();
            return customers.Select(c => new CustomerDto(c));
        }

        public async Task<PaginatedResult<CustomerDto>> ListAsync(int pageNumber, int pageSize)
        {
            var (customers, totalRecords) = await _repository.ListAsync(pageNumber, pageSize);

            return new PaginatedResult<CustomerDto>(
                customers.Select(c => new CustomerDto(c)),
                totalRecords,
                pageNumber,
                pageSize);
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return new CustomerDto(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDTO createCustomerDTO)
        {
            var existingCustomer = await _repository.GetByPhoneNumberAsync(createCustomerDTO.PhoneNumber);
            if (existingCustomer != null)
            {
                throw new InvalidOperationException("A customer with the same phone number already exists.");
            }

            var customer = new Customer(
                id: Guid.NewGuid(), 
                firstName: createCustomerDTO.FirstName,
                lastName: createCustomerDTO.LastName,
                phoneNumber: createCustomerDTO.PhoneNumber
            );
            
            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();

            return new CustomerDto(customer);
        }

        public async Task<CustomerDto> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = await _repository.GetByIdAsync(updateCustomerDTO.Id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {updateCustomerDTO.Id} not found.");
            }

            customer.FirstName = updateCustomerDTO.FirstName;
            customer.LastName = updateCustomerDTO.LastName;

            await _repository.UpdateAsync(customer); //Todo: verify if this needs or not the await
            await _repository.SaveChangesAsync();

            return new CustomerDto(customer);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null)
            {
                return false;
            }

            await _repository.DeleteAsync(customer); //Todo: verify if this needs or not the await
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
