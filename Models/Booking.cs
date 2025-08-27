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
		public int Guests { get; set; }

		[ForeignKey("Table")]
		public int TableId { get; set; }
		public Table Table { get; set; } = null!;

		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		public Customer Customer { get; set; } = null!;

		public Booking() { }

		public Booking(DateTime start, int guests, int tableId, int customerId)
		{
			Start = start;
			End = start.AddHours(2); // Default 2-hour booking
			Guests = guests;
			TableId = tableId;
			CustomerId = customerId;
		}

		public void SetStart(DateTime start)
		{
			Start = start;
			End = start.AddHours(2); // Update end time accordingly
		}
	}
}
