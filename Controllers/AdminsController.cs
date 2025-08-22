using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminsController : ControllerBase
	{
		private readonly IAdminService _adminService;

		public AdminsController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AdminDTO>> GetById(int id)
		{
			var admin = await _adminService.GetByIdAsync(id);
			if (admin is null) { return NotFound(); }
			return Ok(admin);
		}

		[HttpPost("register")]
		public async Task<ActionResult<AdminDTO>> Register(CreateAdminDTO dto)
		{
			var created = await _adminService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(LoginDTO dto)
		{
			var token = await _adminService.LoginAsync(dto);
			if (token is null) { return Unauthorized(); }
			return Ok(token);
		}
	}
}
