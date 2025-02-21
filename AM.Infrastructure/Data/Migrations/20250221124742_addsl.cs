using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addsl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 23);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 21, new TimeOnly(16, 55, 0), new TimeOnly(16, 40, 0) },
                    { 22, new TimeOnly(17, 15, 0), new TimeOnly(17, 0, 0) },
                    { 23, new TimeOnly(17, 35, 0), new TimeOnly(17, 20, 0) }
                });
        }
    }
}
