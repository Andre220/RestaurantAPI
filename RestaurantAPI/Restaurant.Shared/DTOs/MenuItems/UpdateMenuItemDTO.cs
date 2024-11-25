namespace Restaurant.Shared.DTOs.MenuItems
{
    public record UpdateMenuItemDTO(
        Guid Id,
        string Name,
        decimal PriceCents
    );

}
