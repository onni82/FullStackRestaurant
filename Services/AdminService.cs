using System.Security.Cryptography;
using System.Text;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FullStackRestaurant.Services
{
	public class AdminService : IAdminService
	{
		private readonly IAdminRepository _adminRepo;
		private readonly IJwtService _jwtService;
		private readonly IPasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

		public AdminService(IAdminRepository adminRepo, IJwtService jwtService)
		{
			_adminRepo = adminRepo;
			_jwtService = jwtService;
		}

		public async Task<AuthResponseDTO?> LoginAsync(LoginDTO dto)
		{
			var admin = await _adminRepo.GetByUsernameAsync(dto.Username);
			if (admin is null) { return null; }

			var result = _passwordHasher.VerifyHashedPassword(dto.Username, admin.PasswordHash, dto.Password);
			if (result == PasswordVerificationResult.Failed) { return null; }

			var token = _jwtService.GenerateToken(admin.Id, admin.Username);
			return new AuthResponseDTO { Token = token };
		}
	}
}
