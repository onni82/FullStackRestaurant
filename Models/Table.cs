﻿namespace FullStackRestaurant.Models
{
	public class Table
	{
		public int Id { get; set; }
		public int TableNumber { get; set; }
		public int Capacity { get; set; }
		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}
}
