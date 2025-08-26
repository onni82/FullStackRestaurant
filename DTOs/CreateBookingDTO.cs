namespace FullStackRestaurant.DTOs
{
	public class CreateBookingDTO
	{
		public int TableId { get; set; }
		public int CustomerId { get; set; }
		public DateTime Start { get; set; }
		public int Guests { get; set; }
	}
}
