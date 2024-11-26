using Restaurant.Domain.Models;
using Restaurant.Shared.DTOs.Common;
using Restaurant.Shared.DTOs.Customers;

namespace Restaurant.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> ListAllAsync();
        Task<PaginatedResult<CustomerDto>> ListAsync(int pageNumber, int pagesize);
        Task<CustomerDto> GetByIdAsync(Guid id);
        Task<CustomerDto> CreateAsync(CreateCustomerDTO createCustomerDTO);
        Task<CustomerDto> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
