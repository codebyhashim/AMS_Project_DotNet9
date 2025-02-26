using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookedSlots",
                table: "Appoinments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedSlots",
                table: "Appoinments");
        }
    }
}
