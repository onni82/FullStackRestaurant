using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class fixBookingEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "DATEADD(hour, 2, [Start]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "DATEADD(hour, 2, [Start]",
                stored: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
