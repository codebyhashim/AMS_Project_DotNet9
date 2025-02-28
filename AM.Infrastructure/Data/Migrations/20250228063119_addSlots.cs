using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(0, 15, 0), new TimeOnly(0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(0, 30, 0), new TimeOnly(0, 15, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(0, 45, 0), new TimeOnly(0, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(1, 0, 0), new TimeOnly(0, 45, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(1, 15, 0), new TimeOnly(1, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(1, 30, 0), new TimeOnly(1, 15, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(1, 45, 0), new TimeOnly(1, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(2, 0, 0), new TimeOnly(1, 45, 0) });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 9, new TimeOnly(2, 15, 0), new TimeOnly(2, 0, 0) },
                    { 10, new TimeOnly(2, 30, 0), new TimeOnly(2, 15, 0) },
                    { 11, new TimeOnly(2, 45, 0), new TimeOnly(2, 30, 0) },
                    { 12, new TimeOnly(3, 0, 0), new TimeOnly(2, 45, 0) },
                    { 13, new TimeOnly(3, 15, 0), new TimeOnly(3, 0, 0) },
                    { 14, new TimeOnly(3, 30, 0), new TimeOnly(3, 15, 0) },
                    { 15, new TimeOnly(3, 45, 0), new TimeOnly(3, 30, 0) },
                    { 16, new TimeOnly(4, 0, 0), new TimeOnly(3, 45, 0) },
                    { 17, new TimeOnly(4, 15, 0), new TimeOnly(4, 0, 0) },
                    { 18, new TimeOnly(4, 30, 0), new TimeOnly(4, 15, 0) },
                    { 19, new TimeOnly(4, 45, 0), new TimeOnly(4, 30, 0) },
                    { 20, new TimeOnly(5, 0, 0), new TimeOnly(4, 45, 0) },
                    { 21, new TimeOnly(5, 15, 0), new TimeOnly(5, 0, 0) },
                    { 22, new TimeOnly(5, 30, 0), new TimeOnly(5, 15, 0) },
                    { 23, new TimeOnly(5, 45, 0), new TimeOnly(5, 30, 0) },
                    { 24, new TimeOnly(6, 0, 0), new TimeOnly(5, 45, 0) },
                    { 25, new TimeOnly(6, 15, 0), new TimeOnly(6, 0, 0) },
                    { 26, new TimeOnly(6, 30, 0), new TimeOnly(6, 15, 0) },
                    { 27, new TimeOnly(6, 45, 0), new TimeOnly(6, 30, 0) },
                    { 28, new TimeOnly(7, 0, 0), new TimeOnly(6, 45, 0) },
                    { 29, new TimeOnly(7, 15, 0), new TimeOnly(7, 0, 0) },
                    { 30, new TimeOnly(7, 30, 0), new TimeOnly(7, 15, 0) },
                    { 31, new TimeOnly(7, 45, 0), new TimeOnly(7, 30, 0) },
                    { 32, new TimeOnly(8, 0, 0), new TimeOnly(7, 45, 0) },
                    { 33, new TimeOnly(8, 15, 0), new TimeOnly(8, 0, 0) },
                    { 34, new TimeOnly(8, 30, 0), new TimeOnly(8, 15, 0) },
                    { 35, new TimeOnly(8, 45, 0), new TimeOnly(8, 30, 0) },
                    { 36, new TimeOnly(9, 0, 0), new TimeOnly(8, 45, 0) },
                    { 37, new TimeOnly(9, 15, 0), new TimeOnly(9, 0, 0) },
                    { 38, new TimeOnly(9, 30, 0), new TimeOnly(9, 15, 0) },
                    { 39, new TimeOnly(9, 45, 0), new TimeOnly(9, 30, 0) },
                    { 40, new TimeOnly(10, 0, 0), new TimeOnly(9, 45, 0) },
                    { 41, new TimeOnly(10, 15, 0), new TimeOnly(10, 0, 0) },
                    { 42, new TimeOnly(10, 30, 0), new TimeOnly(10, 15, 0) },
                    { 43, new TimeOnly(10, 45, 0), new TimeOnly(10, 30, 0) },
                    { 44, new TimeOnly(11, 0, 0), new TimeOnly(10, 45, 0) },
                    { 45, new TimeOnly(11, 15, 0), new TimeOnly(11, 0, 0) },
                    { 46, new TimeOnly(11, 30, 0), new TimeOnly(11, 15, 0) },
                    { 47, new TimeOnly(11, 45, 0), new TimeOnly(11, 30, 0) },
                    { 48, new TimeOnly(12, 0, 0), new TimeOnly(11, 45, 0) },
                    { 49, new TimeOnly(12, 15, 0), new TimeOnly(12, 0, 0) },
                    { 50, new TimeOnly(12, 30, 0), new TimeOnly(12, 15, 0) },
                    { 51, new TimeOnly(12, 45, 0), new TimeOnly(12, 30, 0) },
                    { 52, new TimeOnly(13, 0, 0), new TimeOnly(12, 45, 0) },
                    { 53, new TimeOnly(13, 15, 0), new TimeOnly(13, 0, 0) },
                    { 54, new TimeOnly(13, 30, 0), new TimeOnly(13, 15, 0) },
                    { 55, new TimeOnly(13, 45, 0), new TimeOnly(13, 30, 0) },
                    { 56, new TimeOnly(14, 0, 0), new TimeOnly(13, 45, 0) },
                    { 57, new TimeOnly(14, 15, 0), new TimeOnly(14, 0, 0) },
                    { 58, new TimeOnly(14, 30, 0), new TimeOnly(14, 15, 0) },
                    { 59, new TimeOnly(14, 45, 0), new TimeOnly(14, 30, 0) },
                    { 60, new TimeOnly(15, 0, 0), new TimeOnly(14, 45, 0) },
                    { 61, new TimeOnly(15, 15, 0), new TimeOnly(15, 0, 0) },
                    { 62, new TimeOnly(15, 30, 0), new TimeOnly(15, 15, 0) },
                    { 63, new TimeOnly(15, 45, 0), new TimeOnly(15, 30, 0) },
                    { 64, new TimeOnly(16, 0, 0), new TimeOnly(15, 45, 0) },
                    { 65, new TimeOnly(16, 15, 0), new TimeOnly(16, 0, 0) },
                    { 66, new TimeOnly(16, 30, 0), new TimeOnly(16, 15, 0) },
                    { 67, new TimeOnly(16, 45, 0), new TimeOnly(16, 30, 0) },
                    { 68, new TimeOnly(17, 0, 0), new TimeOnly(16, 45, 0) },
                    { 69, new TimeOnly(17, 15, 0), new TimeOnly(17, 0, 0) },
                    { 70, new TimeOnly(17, 30, 0), new TimeOnly(17, 15, 0) },
                    { 71, new TimeOnly(17, 45, 0), new TimeOnly(17, 30, 0) },
                    { 72, new TimeOnly(18, 0, 0), new TimeOnly(17, 45, 0) },
                    { 73, new TimeOnly(18, 15, 0), new TimeOnly(18, 0, 0) },
                    { 74, new TimeOnly(18, 30, 0), new TimeOnly(18, 15, 0) },
                    { 75, new TimeOnly(18, 45, 0), new TimeOnly(18, 30, 0) },
                    { 76, new TimeOnly(19, 0, 0), new TimeOnly(18, 45, 0) },
                    { 77, new TimeOnly(19, 15, 0), new TimeOnly(19, 0, 0) },
                    { 78, new TimeOnly(19, 30, 0), new TimeOnly(19, 15, 0) },
                    { 79, new TimeOnly(19, 45, 0), new TimeOnly(19, 30, 0) },
                    { 80, new TimeOnly(20, 0, 0), new TimeOnly(19, 45, 0) },
                    { 81, new TimeOnly(20, 15, 0), new TimeOnly(20, 0, 0) },
                    { 82, new TimeOnly(20, 30, 0), new TimeOnly(20, 15, 0) },
                    { 83, new TimeOnly(20, 45, 0), new TimeOnly(20, 30, 0) },
                    { 84, new TimeOnly(21, 0, 0), new TimeOnly(20, 45, 0) },
                    { 85, new TimeOnly(21, 15, 0), new TimeOnly(21, 0, 0) },
                    { 86, new TimeOnly(21, 30, 0), new TimeOnly(21, 15, 0) },
                    { 87, new TimeOnly(21, 45, 0), new TimeOnly(21, 30, 0) },
                    { 88, new TimeOnly(22, 0, 0), new TimeOnly(21, 45, 0) },
                    { 89, new TimeOnly(22, 15, 0), new TimeOnly(22, 0, 0) },
                    { 90, new TimeOnly(22, 30, 0), new TimeOnly(22, 15, 0) },
                    { 91, new TimeOnly(22, 45, 0), new TimeOnly(22, 30, 0) },
                    { 92, new TimeOnly(23, 0, 0), new TimeOnly(22, 45, 0) },
                    { 93, new TimeOnly(23, 15, 0), new TimeOnly(23, 0, 0) },
                    { 94, new TimeOnly(23, 30, 0), new TimeOnly(23, 15, 0) },
                    { 95, new TimeOnly(23, 45, 0), new TimeOnly(23, 30, 0) },
                    { 96, new TimeOnly(23, 59, 0), new TimeOnly(23, 45, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(9, 30, 0), new TimeOnly(9, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeOnly(10, 30, 0), new TimeOnly(10, 0, 0) });

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
    }
}
