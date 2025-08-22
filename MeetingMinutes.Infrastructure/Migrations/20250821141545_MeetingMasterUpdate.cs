using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MeetingMasterUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Meeting_Minutes_Master_Tbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Meeting_Minutes_Master_Tbl",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
