using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll()
		{
			var customers = await _customerService.GetAllAsync();
			return Ok(customers);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CustomerDTO>> GetById(int id)
		{
			var customer = await _customerService.GetByIdAsync(id);
			if (customer == null) { return NotFound(); }
			return Ok(customer);
		}

		[HttpPost]
		public async Task<ActionResult<CustomerDTO>> Create(CreateCustomerDTO dto)
		{
			var created = await _customerService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id}, created);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _customerService.DeleteAsync(id);
			if (!deleted) { return NotFound(); }
			return NoContent();
		}
	}
}
