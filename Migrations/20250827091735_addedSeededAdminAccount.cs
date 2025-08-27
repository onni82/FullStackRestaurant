using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class addedSeededAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[] { 1, "AQAAAAIAAYagAAAAEMlm8qVFOWLSSwt6dgbRf1ybq5NLBlTgpiU0AGfi5P7v6dqb7HInxtaKN6ZCFjJCxQ==", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
