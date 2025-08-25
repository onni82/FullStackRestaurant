using FullStackRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant.Data
{
	public class FullStackRestaurantDbContext : DbContext
	{
		public FullStackRestaurantDbContext(DbContextOptions<FullStackRestaurantDbContext> options)
			: base(options) { }

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Table> Tables { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<MenuItem> MenuItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Default 2-hour booking
			modelBuilder.Entity<Booking>()
				.Property(b => b.End)
				.HasComputedColumnSql("[Start] + '02:00:00'", stored: true);
			modelBuilder.Entity<Table>()
				.HasIndex(t => t.TableNumber).IsUnique();
		}
	}
}
