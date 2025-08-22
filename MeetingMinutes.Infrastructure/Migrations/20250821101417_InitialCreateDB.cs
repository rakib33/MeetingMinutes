using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Corporate_Customer_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Individual_Customer_Tbl_IndividualCustomerId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropTable(
                name: "MeetingMinutesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_IndividualCustomerId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "AttendsFromClientSide",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "AttendsFromHostSide",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "IndividualCustomerId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingAgenda",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingDateTime",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingDecision",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingDiscussion",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingPlace",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.AddColumn<int>(
                name: "MeetingMinutesMasterId",
                table: "Meeting_Minutes_Details_Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Meeting_Minutes_Details_Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Meeting_Minutes_Details_Tbl",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Unit",
                table: "Meeting_Minutes_Details_Tbl",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Master_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MeetingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeetingPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AttendsFromClientSide = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AttendsFromHostSide = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeetingAgenda = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeetingDiscussion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeetingDecision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CorporateCustomerId = table.Column<int>(type: "int", nullable: true),
                    IndividualCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Minutes_Master_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Master_Tbl_Corporate_Customer_Tbl_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "Corporate_Customer_Tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Master_Tbl_Individual_Customer_Tbl_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "Individual_Customer_Tbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_MeetingMinutesMasterId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingMinutesMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_ProductId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_Id",
                table: "Meeting_Minutes_Master_Tbl",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_IndividualCustomerId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "IndividualCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinutesMasterId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingMinutesMasterId",
                principalTable: "Meeting_Minutes_Master_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "ProductId",
                principalTable: "Products_Service_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinutesMasterId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Master_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_MeetingMinutesMasterId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_ProductId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingMinutesMasterId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.AddColumn<string>(
                name: "AttendsFromClientSide",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AttendsFromHostSide",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IndividualCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingAgenda",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingDateTime",
                table: "Meeting_Minutes_Details_Tbl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingDecision",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingDiscussion",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingPlace",
                table: "Meeting_Minutes_Details_Tbl",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MeetingMinutesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingMinutesMasterId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingMinutesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingMinutesDetails_Meeting_Minutes_Details_Tbl_MeetingMinutesMasterId",
                        column: x => x.MeetingMinutesMasterId,
                        principalTable: "Meeting_Minutes_Details_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingMinutesDetails_Products_Service_Tbl_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Service_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_IndividualCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutesDetails_MeetingMinutesMasterId",
                table: "MeetingMinutesDetails",
                column: "MeetingMinutesMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutesDetails_ProductId",
                table: "MeetingMinutesDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Corporate_Customer_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "CorporateCustomerId",
                principalTable: "Corporate_Customer_Tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Individual_Customer_Tbl_IndividualCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "IndividualCustomerId",
                principalTable: "Individual_Customer_Tbl",
                principalColumn: "Id");
        }
    }
}
