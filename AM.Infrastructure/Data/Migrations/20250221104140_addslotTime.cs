using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addslotTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 13, new TimeOnly(2, 15, 0), new TimeOnly(2, 0, 0) },
                    { 14, new TimeOnly(2, 35, 0), new TimeOnly(2, 20, 0) },
                    { 15, new TimeOnly(2, 55, 0), new TimeOnly(2, 40, 0) },
                    { 16, new TimeOnly(3, 15, 0), new TimeOnly(3, 0, 0) },
                    { 17, new TimeOnly(3, 35, 0), new TimeOnly(3, 20, 0) },
                    { 18, new TimeOnly(3, 55, 0), new TimeOnly(3, 40, 0) },
                    { 19, new TimeOnly(4, 15, 0), new TimeOnly(4, 0, 0) },
                    { 20, new TimeOnly(4, 35, 0), new TimeOnly(4, 20, 0) },
                    { 21, new TimeOnly(4, 55, 0), new TimeOnly(4, 40, 0) },
                    { 22, new TimeOnly(5, 15, 0), new TimeOnly(5, 0, 0) },
                    { 23, new TimeOnly(5, 35, 0), new TimeOnly(5, 20, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 20);

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
    }
}
