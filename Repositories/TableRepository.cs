using Microsoft.EntityFrameworkCore;
using FullStackRestaurant.Data;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;

namespace FullStackRestaurant.Repositories
{
	public class TableRepository : ITableRepository
	{
		private readonly FullStackRestaurantDbContext _context;

		public TableRepository(FullStackRestaurantDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Table>> GetAllAsync()
		{
			return await _context.Tables.ToListAsync();
		}
	}
}
