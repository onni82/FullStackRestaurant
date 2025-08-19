namespace FullStackRestaurant.DTOs
{
	public class BookingDTO
	{
		public int Id { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public int PartySize { get; set; }

		public int TableId { get; set; }
		public string CustomerId { get; set; }
	}

	public class CreateBookingDTO
	{
		public DateTime Start { get; set; }
		public int PartySize { get; set; }
		public int TableId { get; set; }
		public string CustomerId { get; set; }
	}
}
