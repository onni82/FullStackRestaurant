using System.ComponentModel.DataAnnotations;

namespace FullStackRestaurant.Models
{
	public class Admin
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(200)]
		public string Username { get; set; } = null!;
		public string PasswordHash { get; set; } = null!;
	}
}
