namespace FullStackRestaurant.DTOs
{
	public class BookingDTO
	{
		public int Id { get; set; }
		public int TableId { get; set; }
		public int CustomerId { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public int Guests { get; set; }
	}

	public class CreateBookingDTO
	{
		public int TableId { get; set; }
		public int CustomerId { get; set; }
		public DateTime Start { get; set; }
		public int Guests { get; set; }
	}
}
