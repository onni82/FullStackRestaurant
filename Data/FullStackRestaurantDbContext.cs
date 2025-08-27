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
				.HasComputedColumnSql("DATEADD(hour, 2, [Start]", stored: true);
			modelBuilder.Entity<Table>()
				.HasIndex(t => t.TableNumber).IsUnique();
			modelBuilder.Entity<Admin>().HasData(new Admin
			{
				Id = 1,
				Username = "admin",
				PasswordHash = "AQAAAAIAAYagAAAAEMlm8qVFOWLSSwt6dgbRf1ybq5NLBlTgpiU0AGfi5P7v6dqb7HInxtaKN6ZCFjJCxQ==" // Needs to be hashed. The password is password123
			});
		}
	}
}
