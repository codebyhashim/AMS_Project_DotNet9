using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addslotformatchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(14, 15, 0), new TimeOnly(14, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(14, 35, 0), new TimeOnly(14, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(14, 55, 0), new TimeOnly(14, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(15, 15, 0), new TimeOnly(15, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(15, 35, 0), new TimeOnly(15, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(15, 55, 0), new TimeOnly(15, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(16, 15, 0), new TimeOnly(16, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(16, 35, 0), new TimeOnly(16, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(16, 55, 0), new TimeOnly(16, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(17, 15, 0), new TimeOnly(17, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(17, 35, 0), new TimeOnly(17, 20, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(2, 15, 0), new TimeOnly(2, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(2, 35, 0), new TimeOnly(2, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(2, 55, 0), new TimeOnly(2, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(3, 15, 0), new TimeOnly(3, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(3, 35, 0), new TimeOnly(3, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(3, 55, 0), new TimeOnly(3, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(4, 15, 0), new TimeOnly(4, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(4, 35, 0), new TimeOnly(4, 20, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(4, 55, 0), new TimeOnly(4, 40, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(5, 15, 0), new TimeOnly(5, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(5, 35, 0), new TimeOnly(5, 20, 0) });
        }
    }
}
