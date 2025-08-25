using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface ITableRepository
	{
		Task<IEnumerable<Table>> GetAllAsync();
		Task<Table?> GetByIdAsync(int id);
		Task<Table> CreateAsync(Table table);
		Task<Table> UpdateAsync(Table table);
		Task<bool> DeleteAsync(int id);
		Task<IEnumerable<Table>> GetAvailableAsync(DateTime start, int guests);
	}
}
