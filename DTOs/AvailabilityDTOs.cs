namespace FullStackRestaurant.DTOs
{
	public class AvailableTableDTO
	{
		public int Id { get; set; }
		public int TableNumber { get; set; }
		public int Capacity { get; set; }
	}

	public class AvailabilityQueryDTO
	{
		public DateTime Start { get; set; }
		public int Guests { get; set; }
	}
}
