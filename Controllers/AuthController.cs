using FullStackRestaurant.DTOs;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAdminService _adminService;
		public AuthController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDTO dto)
		{
			var res = await _adminService.LoginAsync(dto);
			if (res is null) { return Unauthorized(new { message = "Invalid username or password" }); }
			return Ok(res);
		}
	}
}
