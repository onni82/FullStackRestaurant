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

			modelBuilder.Entity<Table>()
				.HasIndex(t => t.TableNumber).IsUnique();
			modelBuilder.Entity<Admin>().HasData(new Admin
			{
				Id = 1,
				Username = "admin",
				PasswordHash = "AQAAAAIAAYagAAAAEMlm8qVFOWLSSwt6dgbRf1ybq5NLBlTgpiU0AGfi5P7v6dqb7HInxtaKN6ZCFjJCxQ==" // Needs to be hashed. The password is password123
			});
			modelBuilder.Entity<Table>().HasData(
				new Table { Id = 1, TableNumber = 1, Capacity = 2 },
				new Table { Id = 2, TableNumber = 2, Capacity = 4 },
				new Table { Id = 3, TableNumber = 3, Capacity = 4 },
				new Table { Id = 4, TableNumber = 4, Capacity = 6 },
				new Table { Id = 5, TableNumber = 5, Capacity = 8 }
			);
			modelBuilder.Entity<MenuItem>().HasData(
				new MenuItem
				{
					Id = 1,
					Name = "Bibimbap",
					Price = 140.0m,
					Description = "Blandad risskål med blandade grönsaker, nötkött och kryddig gochujangsås.",
					IsPopular = true,
					ImageUrl = "https://i.namu.wiki/i/dgjXU86ae29hDSCza-L0GZlFt3T9lRx1Ug9cKtqWSzMzs7Cd0CN2SzyLFEJcHVFviKcxAlIwxcllT9s2sck0RA.jpg"
				},
				new MenuItem
				{
					Id = 2,
					Name = "Kimchi Jjigae",
					Price = 200.00m,
					Description = "Kryddig kimchigryta med fläsk, tofu och grönsaker.",
					IsPopular = true,
					ImageUrl = "https://i.namu.wiki/i/8drgvI-cQLUfJDC00zbl2ZolK4W3o4ZkVSpR-zM5FZk_QzT58vYnx_7ohk0qwGYYiSLPiZgwccyIEFUtYKDjUQ.webp"
				},
				new MenuItem
				{
					Id = 3,
					Name = "Bulgogi",
					Price = 140.00m,
					Description = "Grillad marinerad biff serveras med ris och grönsaker.",
					IsPopular = true,
					ImageUrl = "https://recipe1.ezmember.co.kr/cache/recipe/2019/03/03/11baafbe81803965b17c3ab42a5992cb1.jpg"
				},
				new MenuItem
				{
					Id = 4,
					Name = "Tteokbokki",
					Price = 90.0m,
					Description = "Kryddiga wokade riskakor med fiskkakor och kokta ägg.",
					IsPopular = false,
					ImageUrl = "https://i.namu.wiki/i/A5AIHovo1xwuEjs7V8-aKpZCSWY2gN3mZEPR9fymaez_J7ufmI9B7YyDBu6kZy9TC9VWJatXVJZbDjcYLO2S8Q.webp"
				},
				new MenuItem
				{
					Id = 5,
					Name = "Samgyeopsal",
					Price = 300.00m,
					Description = "Grillad fläskmage serveras med salladswraps och dippsåser.",
					IsPopular = false,
					ImageUrl = "https://i.namu.wiki/i/oFHlYDjoEh8f-cc3lNK9jAemRkbXxNGwUg7XiW5LGS6DF1P2x8GCeNQxbQhVIwtUS1u53YPw-uoyqpmLtrGNJA.webp"
				}
			);
		}
	}
}
