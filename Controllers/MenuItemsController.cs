using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemsController : ControllerBase
	{
		private readonly IMenuItemService _menuItemService;

		public MenuItemsController(IMenuItemService menuItemService)
		{
			_menuItemService = menuItemService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetAll()
		{
			return Ok(await _menuItemService.GetAllAsync());
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<MenuItemDTO>> GetById(int id)
		{
			var item = await _menuItemService.GetByIdAsync(id);
			return item is null ? NotFound() : Ok(item);
		}

        [Authorize]
        [HttpPost]
		public async Task<ActionResult<MenuItemDTO>> Create([FromBody] CreateMenuItemDTO dto)
		{
			var item = await _menuItemService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
		}

        [Authorize]
        [HttpPut("{id:int}")]
		public async Task<ActionResult<MenuItemDTO>> Update(int id, [FromBody] CreateMenuItemDTO dto)
		{
			var updated = await _menuItemService.UpdateAsync(id, dto);
			return updated is null ? NotFound() : Ok(updated);
		}

        [Authorize]
        [HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _menuItemService.DeleteAsync(id);
			return deleted ? NoContent() : NotFound();
		}
	}
}
