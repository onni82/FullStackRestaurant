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

		public async Task<Table> GetByIdAsync(int id)
		{
			var table = await _context.Tables.FindAsync(id);
			if (table == null) { throw new KeyNotFoundException($"Table with ID {id} not found."); }

			return table;
		}

		public async Task<Table> CreateAsync(Table table)
		{
			_context.Tables.Add(table);
			await _context.SaveChangesAsync();
			return table;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var table = await _context.Tables.FindAsync(id);
			if (table == null) { return false; }

			_context.Tables.Remove(table);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
