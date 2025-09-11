using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface IMenuItemService
	{
		Task<IEnumerable<MenuItemDTO>> GetAllAsync();
		Task<MenuItemDTO?> GetByIdAsync(int id);
		Task<MenuItemDTO> CreateAsync(CreateMenuItemDTO dto);
		Task<MenuItem?> UpdateAsync(int id, UpdateMenuItemDTO dto);

        Task<bool> DeleteAsync(int id);
	}
}
