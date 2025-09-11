using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class MenuItemService : IMenuItemService
	{
		private readonly IMenuItemRepository _menuItemRepo;

		public MenuItemService(IMenuItemRepository menuItemRepo)
		{
			_menuItemRepo = menuItemRepo;
		}

		public async Task<IEnumerable<MenuItemDTO>> GetAllAsync()
		{
			var items = await _menuItemRepo.GetAllAsync();
			return items.Select(m => new MenuItemDTO
			{
				Id = m.Id,
				Name = m.Name,
				Price = m.Price,
				Description = m.Description,
				IsPopular = m.IsPopular,
				ImageUrl = m.ImageUrl
			});
		}

		public async Task<MenuItemDTO?> GetByIdAsync(int id)
		{
			var menuItem = await _menuItemRepo.GetByIdAsync(id);
			return menuItem is null ? null : new MenuItemDTO
			{
				Id = menuItem.Id,
				Name = menuItem.Name,
				Price = menuItem.Price,
				Description = menuItem.Description,
				IsPopular = menuItem.IsPopular,
				ImageUrl = menuItem.ImageUrl
			};
		}

		public async Task<MenuItemDTO> CreateAsync(CreateMenuItemDTO dto)
		{
			var menuItem = new MenuItem
			{
				Name = dto.Name,
				Price = dto.Price,
				Description = dto.Description,
				IsPopular = dto.IsPopular,
				ImageUrl = dto.ImageUrl
			};

			var created = await _menuItemRepo.CreateAsync(menuItem);

			return new MenuItemDTO
			{
				Id = created.Id,
				Name = created.Name,
				Price = created.Price,
				Description = created.Description,
				IsPopular = created.IsPopular,
				ImageUrl = created.ImageUrl
			};
		}

		public async Task<MenuItem?> UpdateAsync(int id, UpdateMenuItemDTO dto)
		{
			await _menuItemRepo.UpdateAsync(id, dto);
			return await _menuItemRepo.GetByIdAsync(id);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _menuItemRepo.DeleteAsync(id);
		}
	}
}
