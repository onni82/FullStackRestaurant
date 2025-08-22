using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingsController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAll()
		{
			var bookings = await _bookingService.GetAllAsync();
			return Ok(bookings);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BookingDTO>> GetById(int id)
		{
			var booking = await _bookingService.GetByIdAsync(id);
			if (booking == null) { return NotFound(); }
			return Ok(booking);
		}

		[HttpPost]
		public async Task<ActionResult<BookingDTO>> Create(CreateBookingDTO dto)
		{
			var booking = await _bookingService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _bookingService.DeleteAsync(id);
			return deleted ? NoContent() : NotFound();
		}
	}
}
