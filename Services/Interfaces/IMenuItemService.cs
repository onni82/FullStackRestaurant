using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface IMenuItemService
	{
		Task<IEnumerable<MenuItemDTO>> GetAllAsync();
		Task<MenuItemDTO?> GetByIdAsync(int id);
		Task<MenuItemDTO> CreateAsync(CreateMenuItemDTO dto);
        Task<MenuItemDTO?> UpdateAsync(int id, CreateMenuItemDTO dto);
        Task<bool> DeleteAsync(int id);
	}
}
