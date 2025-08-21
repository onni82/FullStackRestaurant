using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface ITableService
	{
		IEnumerable<TableDTO> GetAll();
		TableDTO? GetById(int id);
		TableDTO Create(CreateTableDTO dto);
		bool Delete(int id);
	}
}
