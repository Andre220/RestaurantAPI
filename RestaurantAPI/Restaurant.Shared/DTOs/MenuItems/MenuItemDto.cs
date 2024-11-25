using Restaurant.Domain.Models;

namespace Restaurant.Shared.DTOs.MenuItems
{
    public record MenuItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal PriceCents { get; set; }

        public MenuItemDto() { }

        public MenuItemDto(Guid Id, string Name, decimal PriceCents)
        {
            this.Id = Id;
            this.Name = Name;
            this.PriceCents = PriceCents;
        }

        public MenuItemDto(MenuItem menuItem) : this(menuItem.Id, menuItem.Name, menuItem.PriceCents) { }
    }

}
