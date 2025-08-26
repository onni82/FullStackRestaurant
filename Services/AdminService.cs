using System.Security.Cryptography;
using System.Text;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class AdminService : IAdminService
	{
		private readonly IAdminRepository _adminRepo;
		private readonly IJwtService _jwtService;

		public AdminService(IAdminRepository adminRepo, IJwtService jwtService)
		{
			_adminRepo = adminRepo;
			_jwtService = jwtService;
		}

		public async Task<AdminDTO?> GetByIdAsync(int id)
		{
			var admin = await _adminRepo.GetByIdAsync(id);
			return admin is null ? null : new AdminDTO
			{
				Id = admin.Id,
				Username = admin.Username
			};
		}

		public async Task<AdminDTO?> GetByUsernameAsync(string username)
		{
			var admin = await _adminRepository.GetByUsernameAsync(username);
            return admin is null ? null : new AdminDTO
            {
                Id = admin.Id,
                Username = admin.Username
            };
        }

		public async Task<AdminDTO> CreateAsync(CreateAdminDTO dto)
		{
			var passwordHash = HashPassword(dto.Password);

			var admin = new Admin
			{
				Username = dto.Username,
				PasswordHash = passwordHash
			};

			var created = await _adminRepository.CreateAsync(admin);

			return new AdminDTO
			{
				Id = created.Id,
				Username = created.Username
			};
		}

		public async Task<string?> LoginAsync(LoginDTO dto)
		{
			var admin = await _adminRepository.GetByUsernameAsync(dto.Username);
			if (admin is null) { return null; }

			var hash = HashPassword(dto.Password);
			if (admin.PasswordHash != hash) { return null; }

			return _jwtService.GenerateToken(admin);
		}

		private string HashPassword(string password)
		{
			using var sha256 = SHA256.Create();
			var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToBase64String(bytes);
		}
	}
}
