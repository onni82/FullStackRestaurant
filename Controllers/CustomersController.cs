using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Authorize]
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
			return Ok(await _customerService.GetAllAsync());
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<CustomerDTO>> GetById(int id)
		{
			var customer = await _customerService.GetByIdAsync(id);
			return customer is null ? NotFound() : Ok(customer);
		}

		[HttpPost]
		public async Task<ActionResult<CustomerDTO>> Create([FromBody] CreateCustomerDTO dto)
		{
			var created = await _customerService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id}, created);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<CustomerDTO>> Update(int id, [FromBody] CreateCustomerDTO dto)
		{
			var updated = await _customerService.UpdateAsync(id, dto);
			return updated is null ? NotFound() : Ok(updated);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			return (await _customerService.DeleteAsync(id)) ? NoContent() : NotFound();
		}
	}
}
