namespace Restaurant.Shared.DTOs.MenuItems
{
    public record CreateMenuItemDTO(
        string Name,
        decimal PriceCents
    );
}
