using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface IBookingService
	{
		Task<IEnumerable<BookingDTO>> GetAllAsync();
		Task<BookingDTO?> GetByIdAsync(int id);
		Task<BookingDTO> CreateAsync(CreateBookingDTO dto);
		Task<BookingDTO> UpdateAsync(int id, CreateBookingDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
