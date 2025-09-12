using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface IBookingRepository
	{
		Task<IEnumerable<Booking>> GetAllAsync();
		Task<Booking?> GetByIdAsync(int id);
		Task<IEnumerable<Booking>> GetByTableAsync(int tableId);
		Task<Booking> CreateAsync(Booking booking);
		Task<Booking> UpdateAsync(Booking booking);
		Task<bool> DeleteAsync(int id);
	}
}
