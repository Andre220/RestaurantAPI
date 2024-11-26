using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repository.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAllAsync();
        Task<(IEnumerable<Customer>, int)> ListAsync(int pageNumber, int pageSize);
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> GetByPhoneNumberAsync(string phoneNumber);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task SaveChangesAsync();
    }
}
