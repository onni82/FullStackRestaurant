using FullStackRestaurant.Data;
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
			_context.MenuItems.Add(menuItem);
			await _context.SaveChangesAsync();
			return menuItem;
		}

		public async Task<MenuItem> UpdateAsync(MenuItem menuItem)
		{
			_context.MenuItems.Add(menuItem);
			await _context.SaveChangesAsync();
			return menuItem;
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
