using FullStackRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant.Data
{
	public class FullStackRestaurantDbContext : DbContext
	{
		public FullStackRestaurantDbContext(DbContextOptions<FullStackRestaurantDbContext> options)
			: base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Default 2-hour booking
			modelBuilder.Entity<Booking>()
				.Property(b => b.End)
				.HasComputedColumnSql("[Start] + '02:00:00'", stored: true);
		}
	}
}
