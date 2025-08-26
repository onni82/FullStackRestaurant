using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface IMenuItemRepository
	{
		Task<IEnumerable<MenuItem>> GetAllAsync();
		Task<MenuItem?> GetByIdAsync(int id);
		Task<MenuItem> CreateAsync(MenuItem menuItem);
		Task<MenuItem> UpdateAsync(MenuItem menuItem);
		Task<bool> DeleteAsync(int id);
	}
}
