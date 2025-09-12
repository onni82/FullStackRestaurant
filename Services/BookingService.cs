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
			// Get bookings for the specified table
			var existing = await _bookingRepository.GetByTableAsync(dto.TableId);

			var newStart = dto.Start;
			var newEnd = dto.Start.AddHours(2);

			// Check for time conflicts
			bool conflict = existing.Any(b =>
				newStart < b.End &&
				newEnd > b.Start);

			if (conflict)
			{
				throw new Exception("This table is already booked at the selected time.");
			}

			// Create and save the new booking
			var booking = new Booking
			{
				TableId = dto.TableId,
				CustomerId = dto.CustomerId,
				Start = newStart,
				End = newEnd,
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

		public async Task<BookingDTO> UpdateAsync(int id, CreateBookingDTO dto)
		{
			var booking = await _bookingRepository.GetByIdAsync(id);
			if (booking == null)
			{
				throw new KeyNotFoundException("Booking not found.");
			}

			var newStart = dto.Start;
			var newEnd = dto.Start.AddHours(2);

			// Get bookings for the specified table excluding the current booking
			var existing = await _bookingRepository.GetByTableAsync(dto.TableId);

			// Check for time conflicts excluding the current booking
			bool conflict = existing.Any(b =>
				b.Id != id &&
				newStart < b.End &&
				newEnd > b.Start);

			if (conflict)
			{
				throw new InvalidOperationException("This table is already booked at the selected time.");
			}

			// Update and save the booking
			booking.TableId = dto.TableId;
			booking.CustomerId = dto.CustomerId;
			booking.Start = newStart;
			booking.End = newEnd;
			booking.Guests = dto.Guests;

			// Assuming the repository has an UpdateAsync method
			var updated = await _bookingRepository.UpdateAsync(booking);

			return new BookingDTO
			{
				Id = updated.Id,
				TableId = updated.TableId,
				CustomerId = updated.CustomerId,
				Start = updated.Start,
				End = updated.End,
				Guests = updated.Guests
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _bookingRepository.DeleteAsync(id);
		}
	}
}
