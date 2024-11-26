using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Models;
using Restaurant.Repository.DBContext;
using Restaurant.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repository.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> ListAsync()
        {
            return await _context.MenuItems.ToListAsync(); // Retorna todos os MenuItems
        }

        public async Task<MenuItem> GetByIdAsync(Guid id)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(mi => mi.Id == id); // Busca MenuItem por ID
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem); // Adiciona novo MenuItem
        }

        public async Task AddRangeAsync(IEnumerable<MenuItem> menuItems)
        {
            await _context.MenuItems.AddRangeAsync(menuItems);
        }
        public async Task UpdateAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem); // Atualiza MenuItem existente
        }

        public async Task DeleteAsync(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem); // Remove MenuItem
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(); // Salva as alterações no banco
        }
    }
}
