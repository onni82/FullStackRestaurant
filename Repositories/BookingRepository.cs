using FullStackRestaurant.Data;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly FullStackRestaurantDbContext _context;

		public BookingRepository(FullStackRestaurantDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Booking>> GetAllAsync()
		{
			return await _context.Bookings
				.Include(b => b.Table)
				.Include(b => b.Customer)
				.ToListAsync();
		}

		public async Task<Booking?> GetByIdAsync(int id)
		{
			return await _context.Bookings
				.Include(b => b.Table)
				.Include(b => b.Customer)
				.FirstOrDefaultAsync(b => b.Id == id);
		}

		public async Task<Booking> CreateAsync(Booking booking)
		{
			_context.Bookings.Add(booking);
			await _context.SaveChangesAsync();
			return booking;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var booking = await _context.Bookings.FindAsync(id);
			if (booking == null) { return false; }

			_context.Bookings.Remove(booking);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
