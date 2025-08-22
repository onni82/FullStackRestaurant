namespace FullStackRestaurant.DTOs
{
	public class AdminDTO
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
	}

	public class CreateAdminDTO
	{
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}

	public class LoginDTO
	{
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
