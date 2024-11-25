using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repository.Repositories.Interfaces
{
    public  interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> ListAsync();
        Task<MenuItem> GetByIdAsync(Guid id);
        Task AddAsync(MenuItem menuItem);
        Task UpdateAsync(MenuItem menuItem);
        Task DeleteAsync(MenuItem menuItem);
        Task SaveChangesAsync();
    }
}
