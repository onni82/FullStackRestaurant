using FullStackRestaurant.Data;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class TablesController : ControllerBase
	{
		private readonly ITableService _tableService;

		public TablesController(ITableService tableService)
		{
			_tableService = tableService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TableDTO>>> GetAll()
		{
			var tables = await _tableService.GetAllAsync();
			return Ok(tables);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TableDTO>> GetById(int id)
		{
			var table = await _tableService.GetByIdAsync(id);
			return table is null ? NotFound() : Ok(table);
		}

		[HttpPost]
		public async Task<ActionResult<TableDTO>> Create(CreateTableDTO dto)
		{
			var created = await _tableService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _tableService.DeleteAsync(id);
			if (!deleted) { return NotFound(); }
			return NoContent();
		}
	}
}
