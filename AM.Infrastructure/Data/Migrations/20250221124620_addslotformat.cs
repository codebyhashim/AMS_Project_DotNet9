using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addslotformat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 12);

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

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndTime",
                value: new TimeOnly(9, 30, 0));

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(10, 30, 0), new TimeOnly(9, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(11, 30, 0), new TimeOnly(11, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(12, 30, 0), new TimeOnly(12, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(13, 30, 0), new TimeOnly(13, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(14, 30, 0), new TimeOnly(14, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(15, 30, 0), new TimeOnly(15, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(16, 30, 0), new TimeOnly(16, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndTime",
                value: new TimeOnly(9, 15, 0));

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(9, 35, 0), new TimeOnly(9, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(9, 55, 0), new TimeOnly(9, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(10, 15, 0), new TimeOnly(10, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(10, 35, 0), new TimeOnly(10, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(10, 55, 0), new TimeOnly(10, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(11, 15, 0), new TimeOnly(11, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(11, 35, 0), new TimeOnly(11, 20, 0) });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 9, new TimeOnly(11, 55, 0), new TimeOnly(11, 40, 0) },
                    { 10, new TimeOnly(12, 15, 0), new TimeOnly(12, 0, 0) },
                    { 11, new TimeOnly(12, 35, 0), new TimeOnly(12, 20, 0) },
                    { 12, new TimeOnly(12, 55, 0), new TimeOnly(12, 40, 0) },
                    { 13, new TimeOnly(14, 15, 0), new TimeOnly(14, 0, 0) },
                    { 14, new TimeOnly(14, 35, 0), new TimeOnly(14, 20, 0) },
                    { 15, new TimeOnly(14, 55, 0), new TimeOnly(14, 40, 0) },
                    { 16, new TimeOnly(15, 15, 0), new TimeOnly(15, 0, 0) },
                    { 17, new TimeOnly(15, 35, 0), new TimeOnly(15, 20, 0) },
                    { 18, new TimeOnly(15, 55, 0), new TimeOnly(15, 40, 0) },
                    { 19, new TimeOnly(16, 15, 0), new TimeOnly(16, 0, 0) },
                    { 20, new TimeOnly(16, 35, 0), new TimeOnly(16, 20, 0) }
                });
        }
    }
}
