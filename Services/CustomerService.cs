using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepo;

		public CustomerService(ICustomerRepository customerRepo)
		{
			_customerRepo = customerRepo;
		}

		public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
		{
			var customers = await _customerRepo.GetAllAsync();
			return customers.Select(c => new CustomerDTO
			{
				Id = c.Id,
				Name = c.Name,
				PhoneNumber = c.PhoneNumber
			});
		}

		public async Task<CustomerDTO?> GetByIdAsync(int id)
		{
			var customer = await _customerRepo.GetByIdAsync(id);

			return customer is null ? null : new CustomerDTO
			{
				Id = customer.Id,
				Name = customer.Name,
				PhoneNumber = customer.PhoneNumber
			};
		}

		public async Task<CustomerDTO> CreateAsync(CreateCustomerDTO dto)
		{
			var customer = new Customer
			{
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber
			};

			var created = await _customerRepo.CreateAsync(customer);

			return new CustomerDTO
			{
				Id = created.Id,
				Name = created.Name,
				PhoneNumber = created.PhoneNumber
			};
		}

		public async Task<CustomerDTO?> UpdateAsync(int id, CreateCustomerDTO dto)
		{
			var existing = await _customerRepo.GetByIdAsync(id);
			if (existing is null) { return null; }
			existing.Name = dto.Name;
			existing.PhoneNumber = dto.PhoneNumber;
			var updated = await _customerRepo.UpdateAsync(existing);
			return new CustomerDTO
			{
				Id = updated.Id,
				Name = updated.Name,
				PhoneNumber = updated.PhoneNumber
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _customerRepo.DeleteAsync(id);
		}
	}
}
