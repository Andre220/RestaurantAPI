using Restaurant.Shared.DTOs.Customers;
using Restaurant.Shared.DTOs.OrderItems;
using Restaurant.Shared.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IOrderItemService
    {
        Task AddOrderItemAsync(Guid orderId, OrderItemDto orderItemDto);
        Task UpdateOrderItemAsync(Guid orderItemId, OrderItemDto orderItemDto);
        Task DeleteOrderItemAsync(Guid orderItemId);
        Task<IEnumerable<OrderItemDto>> ListOrderItemsByOrderIdAsync(Guid orderId);
    }
}
