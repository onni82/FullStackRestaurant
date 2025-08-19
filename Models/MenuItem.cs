namespace FullStackRestaurant.Models
{
	public class MenuItem
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public decimal Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public string? ImageUrl { get; set; }
	}
}
