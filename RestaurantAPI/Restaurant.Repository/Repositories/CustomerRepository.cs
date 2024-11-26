using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Models;
using Restaurant.Repository.DBContext;
using Restaurant.Repository.Repositories.Interfaces;

namespace Restaurant.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> ListAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<(IEnumerable<Customer>, int)> ListAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _context.Customers.CountAsync();
            var customers = await _context.Customers
                .OrderBy(c => c.LastName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (customers, totalRecords);
        }


        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<bool> ExistsAsync(string phoneNumber)
        {
            return await _context.Customers.AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
