using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addslotTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 18, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 2, 18, 9, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 9, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 2, 18, 9, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 9, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 2, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 2, 18, 10, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 10, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 2, 18, 10, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 10, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 2, 18, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 2, 18, 11, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 11, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 2, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 2, 18, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2025, 2, 18, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 12, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2025, 2, 18, 12, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 12, 40, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slots");
        }
    }
}
