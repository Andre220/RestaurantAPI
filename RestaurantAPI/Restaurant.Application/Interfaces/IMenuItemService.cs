using Restaurant.Shared.DTOs.MenuItems;

namespace Restaurant.Application.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> ListAsync();
        Task<MenuItemDto> GetByIdAsync(Guid id);
        Task<MenuItemDto> CreateAsync(CreateMenuItemDTO menuItemDTO);
        Task<IEnumerable<MenuItemDto>> CreateMultipleAsync(IEnumerable<CreateMenuItemDTO> menuItemDTO);
        Task<MenuItemDto> UpdateAsync(UpdateMenuItemDTO menuItemDTO);
        Task DeleteAsync(Guid id);
    }
}
