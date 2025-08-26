using FullStackRestaurant.Data;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class TableService : ITableService
	{
		private readonly ITableRepository _tableRepo;
		public TableService(ITableRepository tableRepo) {
			_tableRepo = tableRepo;
		}

		public async Task<IEnumerable<TableDTO>> GetAllAsync()
		{
			var tables = await _tableRepo.GetAllAsync();
			return tables.Select(t => new TableDTO { Id = t.Id, TableNumber = t.TableNumber, Capacity = t.Capacity });
		}

		public async Task<TableDTO?> GetByIdAsync(int id)
		{
			var t = await _tableRepo.GetByIdAsync(id);
			return t is null ? null : new TableDTO { Id = t.Id, TableNumber = t.TableNumber, Capacity = t.Capacity };
		}

		public async Task<TableDTO> CreateAsync(CreateTableDTO dto)
		{
			var entity = new Table { TableNumber = dto.TableNumber, Capacity = dto.Capacity };
			var created = await _tableRepo.CreateAsync(entity);
			return new TableDTO { Id = created.Id, TableNumber = created.TableNumber, Capacity = created.Capacity };
		}

		public async Task<TableDTO?> UpdateAsync(int id, CreateTableDTO dto)
		{
			var existing = await _tableRepo.GetByIdAsync(id);
			if (existing is null) return null;
			existing.TableNumber = dto.TableNumber;
			existing.Capacity = dto.Capacity;
			var updated = await _tableRepo.UpdateAsync(existing);
			return new TableDTO { Id = updated.Id, TableNumber = updated.TableNumber, Capacity = updated.Capacity };
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _tableRepo.DeleteAsync(id);
		}

		public async Task<IEnumerable<AvailableTableDTO>> GetAvailableAsync(DateTime start, int guests)
		{
			var result = await _tableRepo.GetAvailableAsync(start, guests);
			return result.Select(t => new AvailableTableDTO { Id = t.Id, TableNumber = t.TableNumber, Capacity = t.Capacity });
		}
	}
}
