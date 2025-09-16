
using System.Text;
using FullStackRestaurant.Data;
using FullStackRestaurant.Repositories;
using FullStackRestaurant.Repositories.Interfaces;
using FullStackRestaurant.Services;
using FullStackRestaurant.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

			builder.Services.AddCors(options => options.AddPolicy("AllowLocal",
				b => b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173", "http://localhost:3000")));

			// JWT auth
			var key = builder.Configuration["Jwt:Key"] ?? "dev_only_change_me_please_1234567890";
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["Jwt:Issuer"],
					ValidAudience = builder.Configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
				};
			});

			builder.Services.AddAuthorization();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseCors("AllowLocal");
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
