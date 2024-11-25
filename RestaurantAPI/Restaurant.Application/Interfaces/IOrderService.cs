using Restaurant.Domain.Models;
using Restaurant.Shared.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> ListAsync();
        Task<OrderDto> GetByIdAsync(Guid id);
        Task<OrderDto> CreateAsync(CreateOrderDto orderDto);
        Task<OrderDto> UpdateAsync(UpdateOrderDto orderDto);
        Task DeleteAsync(Guid id);
    }
}
