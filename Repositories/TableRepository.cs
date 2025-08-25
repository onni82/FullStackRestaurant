using Microsoft.EntityFrameworkCore;
using FullStackRestaurant.Data;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;

namespace FullStackRestaurant.Repositories
{
	public class TableRepository : ITableRepository
	{
		private readonly FullStackRestaurantDbContext _context;
		public TableRepository(FullStackRestaurantDbContext context) => _context = context;

		public async Task<IEnumerable<Table>> GetAllAsync() =>
			await _context.Tables.AsNoTracking().OrderBy(t => t.TableNumber).ToListAsync();

		public Task<Table?> GetByIdAsync(int id) =>
			_context.Tables.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

		public async Task<Table> CreateAsync(Table table)
		{
			_context.Tables.Add(table);
			await _context.SaveChangesAsync();
			return table;
		}

		public async Task<Table> UpdateAsync(Table table)
		{
			_context.Tables.Update(table);
			await _context.SaveChangesAsync();
			return table;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.Tables.FindAsync(id);
			if (entity is null) return false;
			_context.Tables.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Table>> GetAvailableAsync(DateTime start, int guests)
		{
			var min = start.AddHours(-2);
			var max = start.AddHours(2);

			return await _context.Tables
				.AsNoTracking()
				.Where(t => t.Capacity >= guests &&
							!_context.Bookings.Any(b => b.TableId == t.Id &&
														b.Start > min &&
														b.Start < max))
				.OrderBy(t => t.Capacity)
				.ThenBy(t => t.TableNumber)
				.ToListAsync();
		}
	}
}
