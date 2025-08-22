using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;

namespace FullStackRestaurant.Services
{
	public class MenuItemService
	{
		private readonly IMenuItemRepository _menuRepository;

		public MenuItemService(IMenuItemRepository menuRepository)
		{
			_menuRepository = menuRepository;
		}

		public async Task<IEnumerable<MenuItemDTO>> GetAllAsync()
		{
			var items = await _menuRepository.GetAllAsync();
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

			var created = await _menuRepository.CreateAsync(menuItem);

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

		public async Task<bool> DeleteAsync(int id)
		{
			return await _menuRepository.DeleteAsync(id);
		}
	}
}
