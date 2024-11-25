namespace Restaurant.Shared.DTOs.Orders
{
    public record CreateOrderItemDTO(
        Guid MenuItemId, 
        int Quantity);
}
