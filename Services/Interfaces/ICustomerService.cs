using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerDTO>> GetAllAsync();
		Task<CustomerDTO?> GetByIdAsync(int id);
		Task<CustomerDTO> CreateAsync(CustomerDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
