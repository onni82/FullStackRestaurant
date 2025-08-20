using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackRestaurant.Models
{
	public class Booking
	{
		[Key]
		public int Id { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public int PartySize { get; set; }

		[ForeignKey("Table")]
		public int TableId { get; set; }
		public Table Table { get; set; } = null!;

		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		public Customer Customer { get; set; } = null!;
	}
}
