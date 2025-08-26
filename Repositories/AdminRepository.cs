using FullStackRestaurant.Data;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant.Repositories
{
	public class AdminRepository : IAdminRepository
	{
		private readonly FullStackRestaurantDbContext _context;

		public AdminRepository(FullStackRestaurantDbContext context)
		{
			_context = context;
		}

		public async Task<Admin?> GetByUsernameAsync(string username)
		{
			return await _context.Admins.AsNoTracking().FirstOrDefaultAsync(a => a.Username == username);
		}

		public async Task<Admin> CreateAsync(Admin admin)
		{
			_context.Admins.Add(admin);
			await _context.SaveChangesAsync();
			return admin;
		}
	}
}
