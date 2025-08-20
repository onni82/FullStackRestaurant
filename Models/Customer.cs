﻿using System.ComponentModel.DataAnnotations;

namespace FullStackRestaurant.Models
{
	public class Customer
	{
        [Key]
        public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Phone { get; set; } = null!;

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}
}
