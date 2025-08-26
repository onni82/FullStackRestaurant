
using FullStackRestaurant.Data;
using FullStackRestaurant.Repositories;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStackRestaurant
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// App specific services.
			builder.Services.AddDbContext<FullStackRestaurantDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			// Scoped repositories
			builder.Services.AddScoped<ITableRepository, TableRepository>();
			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
			builder.Services.AddScoped<IBookingRepository, BookingRepository>();
			builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
			builder.Services.AddScoped<IAdminRepository, AdminRepository>();

            // Scoped services
            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
			builder.Services.AddScoped<IJwtService, JwtService>();

			// Add services to the container.
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
