using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateMeetingDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Meeting_Minutes_Details_Tbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
