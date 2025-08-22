namespace FullStackRestaurant.DTOs
{
	public class MenuItemDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public bool IsPopular { get; set; }
		public string? ImageUrl { get; set; }
	}

	public class CreateMenuItemDTO
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public bool IsPopular { get; set; }
		public string? ImageUrl { get; set; }
	}
}
