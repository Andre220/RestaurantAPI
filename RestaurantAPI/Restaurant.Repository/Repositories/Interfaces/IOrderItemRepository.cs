using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repository.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> ListByOrderIdAsync(Guid orderId);
        Task<OrderItem> GetByIdAsync(Guid id);
        Task AddAsync(OrderItem orderItem);
        Task UpdateAsync(OrderItem orderItem);
        Task DeleteAsync(OrderItem orderItem);
        Task SaveChangesAsync();
    }
}
