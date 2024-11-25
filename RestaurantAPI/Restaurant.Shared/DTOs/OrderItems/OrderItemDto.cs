using Restaurant.Domain.Models;

namespace Restaurant.Shared.DTOs.OrderItems
{
    public record OrderItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }

        public OrderItemDto() { }

        public OrderItemDto(Guid Id, int Quantity, Guid OrderId, Guid ItemId)
        {
            this.Id = Id;
            this.Quantity = Quantity;
            this.OrderId = OrderId;
            this.ItemId = ItemId;
        }

        public OrderItemDto(OrderItem item)
            : this(item.Id, item.Quantity, item.OrderId, item.ItemId) { }
    }

}
