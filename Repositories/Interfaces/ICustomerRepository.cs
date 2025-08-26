﻿using FullStackRestaurant.Models;

namespace FullStackRestaurant.Repositories.Interfaces
{
	public interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> GetAllAsync();
		Task<Customer?> GetByIdAsync(int id);
		Task<Customer> CreateAsync(Customer customer);
		Task<Customer> UpdateAsync(Customer customer);
		Task<bool> DeleteAsync(int id);
	}
}
