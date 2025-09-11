using FullStackRestaurant.DTOs;

namespace FullStackRestaurant.Services.Interfaces
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerDTO>> GetAllAsync();
		Task<CustomerDTO?> GetByIdAsync(int id);
		Task<CustomerDTO> CreateAsync(CreateCustomerDTO dto);
		Task<CustomerDTO?> UpdateAsync(int id, CreateCustomerDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
