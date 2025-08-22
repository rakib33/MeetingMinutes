using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class meetingModelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttendsFromHostSide",
                table: "Meeting_Minutes_Master_Tbl",
                newName: "AttendHostSide");

            migrationBuilder.RenameColumn(
                name: "AttendsFromClientSide",
                table: "Meeting_Minutes_Master_Tbl",
                newName: "AttendClientSide");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttendHostSide",
                table: "Meeting_Minutes_Master_Tbl",
                newName: "AttendsFromHostSide");

            migrationBuilder.RenameColumn(
                name: "AttendClientSide",
                table: "Meeting_Minutes_Master_Tbl",
                newName: "AttendsFromClientSide");
        }
    }
}
