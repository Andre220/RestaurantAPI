using Restaurant.Domain.Identity;

namespace Restaurant.Domain.Models
{
    public enum OrderStatus
    {
        Pending = 0,
        Cooking = 1,
        Ready = 2,
        Delivered = 3,
        Cancelled = 4
    }

    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPriceCents { get; set; }
        public Customer Customer { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User? UpdatedBy { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
