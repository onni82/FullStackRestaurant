using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class updatedBookingEndSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "DATEADD(hour, 2, [Start]",
                stored: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "[Start] + '02:00:00'",
                oldStored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "[Start] + '02:00:00'",
                stored: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "DATEADD(hour, 2, [Start]",
                oldStored: true);
        }
    }
}
