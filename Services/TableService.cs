using FullStackRestaurant.Data;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class TableService :ITableService
	{
		private readonly ITableRepository _tableRepository;

		public TableService(ITableRepository tableRepository)
		{
			_tableRepository = tableRepository;
		}

		public async Task<IEnumerable<TableDTO>> GetAllAsync()
		{
			var tables = await _tableRepository.GetAllAsync();
			return tables.Select(t => new TableDTO
			{
				Id = t.Id,
				TableNumber = t.TableNumber,
				Capacity = t.Capacity
			});
		}

		public async Task<TableDTO?> GetByIdAsync(int id)
		{
			var t = await _tableRepository.GetByIdAsync(id);
			if (t == null) { return null; }

			return new TableDTO
			{
				Id = t.Id,
				TableNumber = t.TableNumber,
				Capacity = t.Capacity
			};
		}

		public async Task<TableDTO> CreateAsync(CreateTableDTO dto)
		{
			var table = new Table
			{
				TableNumber = dto.TableNumber,
				Capacity = dto.Capacity
			};

			var created = await _tableRepository.CreateAsync(table);

			return new TableDTO
			{
				Id = created.Id,
				TableNumber = created.TableNumber,
				Capacity = created.Capacity
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _tableRepository.DeleteAsync(id);
		}
	}
}
