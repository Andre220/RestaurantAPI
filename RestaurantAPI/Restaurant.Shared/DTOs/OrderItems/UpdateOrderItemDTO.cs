namespace Restaurant.Shared.DTOs.OrderItems
{
    public record UpdateOrderItemDTO(
        Guid Id,
        int Quantity
    );
}
