using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly ITableService _tableService;

		public BookingsController(IBookingService bookingService, ITableService tableService)
		{
			_bookingService = bookingService;
			_tableService = tableService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAll()
		{
			return Ok(await _bookingService.GetAllAsync());
        }

		[HttpGet("{id:int}")]
		public async Task<ActionResult<BookingDTO>> GetById(int id)
		{
			var dto = await _bookingService.GetByIdAsync(id);
			return dto is null ? NotFound() : Ok(dto);
		}

		[HttpPost]
		public async Task<ActionResult<BookingDTO>> Create([FromBody] CreateBookingDTO dto)
		{
			try
			{
				var created = await _bookingService.CreateAsync(dto);
				return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(new { error = ex.Message });
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
            return (await _bookingService.DeleteAsync(id)) ? NoContent() : NotFound();
        }

		[HttpGet("available-tables")]
		public async Task<ActionResult<IEnumerable<AvailableTableDTO>>> AvailableTables([FromQuery] DateTime start, [FromQuery] int guests)
		{
			if (guests <= 0) { return BadRequest("Guests must be > 0."); }
			var res = await _tableService.GetAvailableAsync(start, guests);
			return Ok(res);
		}
	}
}
