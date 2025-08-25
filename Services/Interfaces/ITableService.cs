using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface ITableService
	{
		Task<IEnumerable<TableDTO>> GetAllAsync();
		Task<TableDTO?> GetByIdAsync(int id);
		Task<TableDTO> CreateAsync(CreateTableDTO dto);
		Task<TableDTO?> UpdateAsync(int id, CreateTableDTO dto);
		Task<bool> DeleteAsync(int id);
		Task<IEnumerable<AvailableTableDTO>> GetAvailableAsync(DateTime start, int guests);
	}
}
