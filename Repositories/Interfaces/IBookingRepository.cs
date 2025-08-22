using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface IBookingRepository
	{
		Task<IEnumerable<Booking>> GetAllAsync();
		Task<Booking?> GetByIdAsync(int id);
		Task<Booking> CreateAsync(Booking booking);
		Task<bool> DeleteAsync(int id);
	}
}
