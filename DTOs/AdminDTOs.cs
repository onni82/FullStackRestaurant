namespace FullStackRestaurant.DTOs
{
	public class AdminDTO
	{
		public int Id { get; set; }
		public string Username { get; set; } = null!;
	}
	public class CreateAdminDTO
	{
		public string Username { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
