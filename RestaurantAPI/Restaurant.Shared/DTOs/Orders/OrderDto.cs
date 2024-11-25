using Restaurant.Domain.Identity;
using Restaurant.Domain.Models;
using Restaurant.Shared.DTOs.Customers;
using Restaurant.Shared.DTOs.OrderItems;

namespace Restaurant.Shared.DTOs.Orders
{
    public record OrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPriceCents { get; set; }
        public CustomerDto Customer { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }

        public OrderDto() { }

        public OrderDto(
            Guid Id,
            DateTime CreatedAt,
            OrderStatus Status,
            decimal TotalPriceCents,
            CustomerDto Customer,
            IEnumerable<OrderItemDto> OrderItems)
        {
            this.Id = Id;
            this.CreatedAt = CreatedAt;
            this.Status = Status;
            this.TotalPriceCents = TotalPriceCents;
            this.Customer = Customer;
            this.OrderItems = OrderItems;
        }

        public OrderDto(Order order)
            : this(
                order.Id,
                order.CreatedAt,
                order.Status,
                order.TotalPriceCents,
                new CustomerDto(order.Customer),
                order.OrderItems.Select(oi => new OrderItemDto(oi)))
        {
        }
    }

}
