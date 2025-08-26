using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface IAdminService
	{
		Task<AuthResponseDTO?> LoginAsync(LoginDTO dto); // returns JWT
	}
}
