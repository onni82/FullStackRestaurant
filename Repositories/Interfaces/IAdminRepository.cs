using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface IAdminRepository
	{
		Task<Admin?> GetByUsernameAsync(string username);
		Task<Admin> CreateAsync(Admin admin);
	}
}
