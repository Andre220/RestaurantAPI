using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.Repositories.Interfaces;
using Restaurant.Shared.DTOs.MenuItems;

namespace Restaurant.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;

        public MenuItemService(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MenuItemDto>> ListAsync()
        {
            var menuItems = await _repository.ListAsync();
            return menuItems.Select(m => new MenuItemDto(m));
        }

        public async Task<MenuItemDto> GetByIdAsync(Guid id)
        {
            var menuItem = await _repository.GetByIdAsync(id);
            
            if (menuItem == null)
            {
                throw new Exception("Menu item not found");
            }

            return new MenuItemDto(menuItem);
        }

        public async Task<MenuItemDto> CreateAsync(CreateMenuItemDTO menuItemDTO)
        {
            var menuItem = new MenuItem
            {
                Id = Guid.NewGuid(),
                Name = menuItemDTO.Name,
                PriceCents = menuItemDTO.PriceCents
            };

            await _repository.AddAsync(menuItem);
            await _repository.SaveChangesAsync();

            return new MenuItemDto(menuItem);
        }

        public async Task<MenuItemDto> UpdateAsync(UpdateMenuItemDTO menuItemDTO)
        {
            var menuItem = await _repository.GetByIdAsync(menuItemDTO.Id);
            if (menuItem == null)
            {
                throw new Exception("Menu item not found");
            }

            menuItem.Name = menuItemDTO.Name;
            menuItem.PriceCents = menuItemDTO.PriceCents;

            await _repository.UpdateAsync(menuItem);
            await _repository.SaveChangesAsync();

            return new MenuItemDto(menuItem);
        }

        public async Task DeleteAsync(Guid id)
        {
            var menuItem = await _repository.GetByIdAsync(id);
            if (menuItem == null)
            {
                throw new Exception("Menu item not found");
            }

            await _repository.DeleteAsync(menuItem);
            await _repository.SaveChangesAsync();
        }
    }
}
