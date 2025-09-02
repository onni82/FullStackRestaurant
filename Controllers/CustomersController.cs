using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

		[HttpPost]
		public async Task<ActionResult<CustomerDTO>> Create([FromBody] CreateCustomerDTO dto)
		{
			var created = await _customerService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[Authorize]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll()
		{
			return Ok(await _customerService.GetAllAsync());
		}

		[Authorize]
		[HttpGet("{id:int}")]
		public async Task<ActionResult<CustomerDTO>> GetById(int id)
		{
			var customer = await _customerService.GetByIdAsync(id);
			return customer is null ? NotFound() : Ok(customer);
		}

		[Authorize]
		[HttpPut("{id:int}")]
		public async Task<ActionResult<CustomerDTO>> Update(int id, [FromBody] CreateCustomerDTO dto)
		{
			var updated = await _customerService.UpdateAsync(id, dto);
			return updated is null ? NotFound() : Ok(updated);
		}

		[Authorize]
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			return (await _customerService.DeleteAsync(id)) ? NoContent() : NotFound();
		}
	}
}
