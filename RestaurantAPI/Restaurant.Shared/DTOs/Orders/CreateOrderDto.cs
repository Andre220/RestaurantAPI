using Restaurant.Domain.Models;
using Restaurant.Shared.DTOs.Customers;

namespace Restaurant.Shared.DTOs.Orders
{
    public record CreateOrderDto(
        CustomerDto Customer,
        List<CreateOrderItemDTO> OrderItems
    ); 
}
