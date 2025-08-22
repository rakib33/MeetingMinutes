using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corporate_Customer_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporate_Customer_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Individual_Customer_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual_Customer_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Service_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Service_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Details_Tbl",
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
                    table.PrimaryKey("PK_Meeting_Minutes_Details_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Details_Tbl_Corporate_Customer_Tbl_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "Corporate_Customer_Tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Details_Tbl_Individual_Customer_Tbl_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "Individual_Customer_Tbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeetingMinutesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MeetingMinutesMasterId = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_Corporate_Customer_Tbl_Id",
                table: "Corporate_Customer_Tbl",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Corporate_Customer_Tbl_Name",
                table: "Corporate_Customer_Tbl",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_Customer_Tbl_Id",
                table: "Individual_Customer_Tbl",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_Customer_Tbl_Name",
                table: "Individual_Customer_Tbl",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_Id",
                table: "Meeting_Minutes_Details_Tbl",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_Service_Tbl_Id",
                table: "Products_Service_Tbl",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Service_Tbl_Name",
                table: "Products_Service_Tbl",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingMinutesDetails");

            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropTable(
                name: "Products_Service_Tbl");

            migrationBuilder.DropTable(
                name: "Corporate_Customer_Tbl");

            migrationBuilder.DropTable(
                name: "Individual_Customer_Tbl");
        }
    }
}
