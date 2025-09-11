using FullStackRestaurant.Data;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant.Repositories
{
	public class MenuItemRepository : IMenuItemRepository
	{
		private readonly FullStackRestaurantDbContext _context;

		public MenuItemRepository(FullStackRestaurantDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<MenuItem>> GetAllAsync()
		{
			return await _context.MenuItems.AsNoTracking().OrderBy(menuItem => menuItem.Name).ToListAsync();
		}

		public async Task<MenuItem?> GetByIdAsync(int id)
		{
			return await _context.MenuItems.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<MenuItem> CreateAsync(MenuItem menuItem)
		{
			menuItem.Id = 0;

			_context.MenuItems.Add(menuItem);
			await _context.SaveChangesAsync();

			return menuItem;
		}

		public async Task<MenuItem> UpdateAsync(int id, UpdateMenuItemDTO dto)
		{
			var existing = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
			if (existing != null)
			{
				throw new Exception("Menu item not found");
			}

			existing.Name = dto.Name;
			existing.Description = dto.Description;
			existing.Price = dto.Price;
			existing.IsPopular = dto.IsPopular;
			existing.ImageUrl = dto.ImageUrl;

			await _context.SaveChangesAsync();
			return existing;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var menuItem = await _context.MenuItems.FindAsync(id);
			if (menuItem == null) { return false; }

			_context.MenuItems.Remove(menuItem);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
