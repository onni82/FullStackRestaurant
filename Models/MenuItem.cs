using System.ComponentModel.DataAnnotations;

namespace FullStackRestaurant.Models
{
	public class MenuItem
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(200)]
		public string Name { get; set; } = null!;
		public decimal Price { get; set; }
		public string Description { get; set; } = null!;
		public bool IsPopular { get; set; }
		public string? ImageUrl { get; set; }
	}
}
