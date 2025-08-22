using FullStackRestaurant.Models;

namespace FullStackRestaurant.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Admin admin);
    }
}
