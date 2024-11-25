namespace Restaurant.Shared.DTOs.OrderItems
{
    public record CreateOrderItemDTO(
        int Quantity,
        Guid OrderId,
        Guid ItemId
    );
}
