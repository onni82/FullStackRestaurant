using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services.Interfaces;

namespace FullStackRestaurant.Services
{
	public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone
            });
        }

        public async Task<CustomerDTO?> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) { return null; }

            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone
            };
        }

        public async Task<CustomerDTO> CreateAsync(CreateCustomerDTO dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Phone = dto.Phone
            };

            var created = await _customerRepository.CreateAsync(customer);

            return new CustomerDTO
            {
                Id = created.Id,
                Name = created.Name,
                Phone = created.Phone
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }
    }
}
