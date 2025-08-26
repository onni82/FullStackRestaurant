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
		public async Task<ActionResult<IEnumerable<TableDTO>>> GetAll() => Ok(await _tableService.GetAllAsync());

		[HttpGet("{id:int}")]
		public async Task<ActionResult<TableDTO>> GetById(int id)
		{
			var table = await _tableService.GetByIdAsync(id);
			return table is null ? NotFound() : Ok(table);
		}

		[HttpPost]
		public async Task<ActionResult<TableDTO>> Create([FromBody] CreateTableDTO dto)
		{
			var created = await _tableService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<TableDTO>> Update(int id, [FromBody] CreateTableDTO dto)
		{
			var updated = await _tableService.UpdateAsync(id, dto);
			return updated is null ? NotFound() : Ok(updated);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id) => (await _tableService.DeleteAsync(id)) ? NoContent() : NotFound();

		[HttpGet("available")]
		public async Task<ActionResult<IEnumerable<AvailableTableDTO>>> GetAvailable([FromQuery] DateTime start, [FromQuery] int guests)
		{
			if (guests <= 0) { return BadRequest("Guests must be > 0."); }
			
			var result = await _tableService.GetAvailableAsync(start, guests);
			return Ok(result);
		}
	}
}
