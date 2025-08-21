using FullStackRestaurant.Data;
using FullStackRestaurant.Models;
using FullStackRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly FullStackRestaurantDbContext _context;

		public CustomerRepository(FullStackRestaurantDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Customer>> GetAllAsync()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer?> GetByIdAsync(int id)
		{
			return await _context.Customers.FindAsync(id);
		}

		public async Task<Customer> CreateAsync(Customer customer)
		{
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();
			return customer;
		}
		public async Task<bool> DeleteAsync(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null) { return false; }

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
