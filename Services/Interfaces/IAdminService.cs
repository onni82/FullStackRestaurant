using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface IAdminService
	{
		Task<AdminDTO?> GetByIdAsync(int id);
		Task<AdminDTO?> GetByUsernameAsync(string username);
		Task<AdminDTO> CreateAsync(CreateAdminDTO dto);
		Task<string?> LoginAsync(LoginDTO dto); // returns JWT
	}
}
