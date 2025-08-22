using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class BookingService : IBookingService
	{
		private readonly IBookingRepository _bookingRepository;

		public BookingService(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}

		public async Task<IEnumerable<BookingDTO>> GetAllAsync()
		{
			var bookings = await _bookingRepository.GetAllAsync();
			return bookings.Select(b => new BookingDTO
			{
				Id = b.Id,
				TableId = b.TableId,
				CustomerId = b.CustomerId,
				Start = b.Start,
				End = b.End,
				Guests = b.Guests
			});
		}

		public async Task<BookingDTO?> GetByIdAsync(int id)
		{
			var booking = await _bookingRepository.GetByIdAsync(id);
			if (booking == null) { return null; }

			return new BookingDTO
			{
				Id = booking.Id,
				TableId = booking.TableId,
				CustomerId = booking.CustomerId,
				Start = booking.Start,
				End = booking.End,
				Guests = booking.Guests
			};
		}

		public async Task<BookingDTO> CreateAsync(CreateBookingDTO dto)
		{
			var booking = new Booking
			{
				TableId = dto.TableId,
				CustomerId = dto.CustomerId,
				Start = dto.Start,
				// End = dto.Start.AddHours(2), // Assuming a default duration of 2 hours
				Guests = dto.Guests
			};

			var created = await _bookingRepository.CreateAsync(booking);
			
			return new BookingDTO
			{
				Id = created.Id,
				TableId = created.TableId,
				CustomerId = created.CustomerId,
				Start = created.Start,
				End = created.End,
				Guests = created.Guests
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _bookingRepository.DeleteAsync(id);
		}
	}
}
