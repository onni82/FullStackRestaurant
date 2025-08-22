using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
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
			var items = await _menuItemService.GetAllAsync();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<MenuItemDTO>> GetById(int id)
		{
			var item = await _menuItemService.GetByIdAsync(id);
			if (item == null) { return NotFound(); }
			return Ok(item);
		}

		[HttpPost]
		public async Task<ActionResult<MenuItemDTO>> Create(CreateMenuItemDTO dto)
		{
			var item = await _menuItemService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _menuItemService.DeleteAsync(id);
			return deleted ? NoContent() : NotFound();
		}
	}
}
