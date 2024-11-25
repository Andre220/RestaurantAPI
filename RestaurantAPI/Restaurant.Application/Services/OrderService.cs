using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.Repositories.Interfaces;
using Restaurant.Shared.DTOs.Customers;
using Restaurant.Shared.DTOs.OrderItems;
using Restaurant.Shared.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ICustomerRepository _customerRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public OrderService(IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IMenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<OrderDto>> ListAsync()
        {
            var orders = await _orderRepository.ListAsync();
            return orders.Select(o => new OrderDto(o));
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return new OrderDto(order);
        }

        public async Task<OrderDto> CreateAsync(CreateOrderDto orderDto)
        {
            Customer customer = await GetByPhoneNumberAsync(orderDto.Customer.PhoneNumber);

            if (customer == null)
            {
                customer = new Customer
                (
                    id: Guid.NewGuid(),
                    phoneNumber: orderDto.Customer.PhoneNumber,
                    firstName: orderDto.Customer.FirstName,
                    lastName: orderDto.Customer.LastName
                );

                await _customerRepository.AddAsync(customer);
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                Customer = customer,
                TotalPriceCents = 0,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in orderDto.OrderItems)
            {
                var menuItem = await _menuItemRepository.GetByIdAsync(item.MenuItemId);
                if (menuItem == null)
                {
                    throw new Exception($"Menu item with ID {item.MenuItemId} not found.");
                }

                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    MenuItem = menuItem,
                    Quantity = item.Quantity,
                    Order = order
                };

                order.OrderItems.Add(orderItem);
                order.TotalPriceCents += menuItem.PriceCents * item.Quantity;
            }
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return new OrderDto(order);
        }

        public async Task<OrderDto> UpdateAsync(UpdateOrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(orderDto.Id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            order.Status = orderDto.Status;
            order.UpdatedAt = DateTime.UtcNow;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();

            return new OrderDto(order);
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            await _orderRepository.DeleteAsync(order);
            await _orderRepository.SaveChangesAsync();
        }

        private async Task<Customer> GetByPhoneNumberAsync(string phoneNumber)
        {
            var result = await _customerRepository.GetByPhoneNumberAsync(phoneNumber);

            return result;
        }
    }
}
