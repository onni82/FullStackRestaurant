using FullStackRestaurant.Data;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class TableService :ITableService
	{
		private readonly FullStackRestaurantDbContext _context;

		public TableService(FullStackRestaurantDbContext context)
		{
			_context = context;
		}

		public IEnumerable<TableDTO> GetAll()
		{
			return _context.Tables.Select(t => new TableDTO
			{
				Id = t.Id,
				TableNumber = t.TableNumber,
				Capacity = t.Capacity
			}).ToList();
		}

		public TableDTO? GetById(int id)
		{
			var t = _context.Tables.Find(id);
			if (t == null) { return null; }

			return new TableDTO
			{
				Id = t.Id,
				TableNumber = t.TableNumber,
				Capacity = t.Capacity
			};
		}

		public TableDTO Create(CreateTableDTO dto)
		{
			var table = new Table
			{
				TableNumber = dto.TableNumber,
				Capacity = dto.Capacity
			};

			_context.Tables.Add(table);
			_context.SaveChanges();

			return new TableDTO
			{
				Id = table.Id,
				TableNumber = table.TableNumber,
				Capacity = table.Capacity
			};
		}

		public bool Delete(int id)
		{
			var table = _context.Tables.Find(id);
			if (table == null) { return false; };

			_context.Tables.Remove(table);
			_context.SaveChanges();
			return true;
		}
	}
}
