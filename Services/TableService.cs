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
		private readonly ITableRepository _tableRepository;
		public TableService(ITableRepository tableRepository) => _tableRepository = tableRepository;

		public async Task<IEnumerable<TableDTO>> GetAllAsync()
		{
			var tables = await _tableRepository.GetAllAsync();
			return tables.Select(t => new TableDTO { Id = t.Id, TableNumber = t.TableNumber, Capacity = t.Capacity });
		}

		public async Task<TableDTO?> GetByIdAsync(int id)
		{
			var t = await _tableRepository.GetByIdAsync(id);
			return t is null ? null : new TableDTO { Id = t.Id, TableNumber = t.TableNumber, Capacity = t.Capacity };
		}

		public async Task<TableDTO> CreateAsync(CreateTableDTO dto)
		{
			var entity = new Table { TableNumber = dto.TableNumber, Capacity = dto.Capacity };
			var created = await _tableRepository.CreateAsync(entity);
			return new TableDTO { Id = created.Id, TableNumber = created.TableNumber, Capacity = created.Capacity };
		}

		public async Task<TableDTO?> UpdateAsync(int id, CreateTableDTO dto)
		{
			var existing = await _tableRepository.GetByIdAsync(id);
			if (existing is null) return null;
			existing.TableNumber = dto.TableNumber;
			existing.Capacity = dto.Capacity;
			var updated = await _tableRepository.UpdateAsync(existing);
			return new TableDTO { Id = updated.Id, TableNumber = updated.TableNumber, Capacity = updated.Capacity };
		}

		public Task<bool> DeleteAsync(int id) => _tableRepository.DeleteAsync(id);

		public async Task<IEnumerable<AvailableTableDTO>> GetAvailableAsync(DateTime start, int guests)
		{
			var result = await _tableRepository.GetAvailableAsync(start, guests);
			return result.Select(t => new AvailableTableDTO { Id = t.Id, TableNumber = t.TableNumber, Capacity = t.Capacity });
		}
	}
}
