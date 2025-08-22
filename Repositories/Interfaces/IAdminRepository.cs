using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface IAdminRepository
	{
		Task<Admin?> GetByIdAsync(int id);
		Task<Admin?> GetByUsernameAsync(string username);
		Task<Admin> CreateAsync(Admin admin);
	}
}
