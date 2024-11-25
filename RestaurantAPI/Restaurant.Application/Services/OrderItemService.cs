using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.Repositories.Interfaces;
using Restaurant.Shared.DTOs.OrderItems;

namespace Restaurant.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMenuItemRepository menuItemRepository)
        {
            _orderItemRepository = orderItemRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task AddOrderItemAsync(Guid orderId, OrderItemDto orderItemDTO)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(orderItemDTO.Id);
            if (menuItem == null)
            {
                throw new Exception("Menu item not found");
            }

            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                MenuItem = menuItem,
                Quantity = orderItemDTO.Quantity
            };

            await _orderItemRepository.AddAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();
        }

        public async Task UpdateOrderItemAsync(Guid orderItemId, OrderItemDto orderItemDTO)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
            if (orderItem == null)
            {
                throw new Exception("Order item not found");
            }

            var menuItem = await _menuItemRepository.GetByIdAsync(orderItemDTO.Id);
            if (menuItem == null)
            {
                throw new Exception("Menu item not found");
            }

            orderItem.MenuItem = menuItem;
            orderItem.Quantity = orderItemDTO.Quantity;

            await _orderItemRepository.UpdateAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(Guid orderItemId)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
            if (orderItem == null)
            {
                throw new Exception("Order item not found");
            }

            await _orderItemRepository.DeleteAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItemDto>> ListOrderItemsByOrderIdAsync(Guid orderId)
        {
            var orderItems = await _orderItemRepository.ListByOrderIdAsync(orderId);
            return orderItems.Select(oi => new OrderItemDto(oi.Id, oi.Quantity, oi.MenuItem.Id, oi.OrderId));
        }
    }
}
