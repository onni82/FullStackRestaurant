using FullStackRestaurant.Models;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface IJwtService
	{
		string GenerateToken(int adminId, string username);
	}
}
