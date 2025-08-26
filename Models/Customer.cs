using System.ComponentModel.DataAnnotations;

namespace FullStackRestaurant.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(200)][Required]
		public string Name { get; set; } = null!;
		[Required]
		public string PhoneNumber { get; set; } = null!;

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}
}
