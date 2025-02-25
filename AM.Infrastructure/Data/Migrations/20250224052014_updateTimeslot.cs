using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTimeslot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new TimeOnly(10, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new TimeOnly(9, 30, 0));
        }
    }
}
