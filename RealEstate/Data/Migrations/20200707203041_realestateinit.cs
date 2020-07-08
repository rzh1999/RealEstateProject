using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Data.Migrations
{
    public partial class realestateinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false),
                    Longitude = table.Column<int>(nullable: false),
                    Latitude = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });


            migrationBuilder.CreateTable(
                name: "Checklist",
                columns: table => new
                {
                    ChecklistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositPaid = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsOfferMade = table.Column<bool>(nullable: false),
                    IsInspected = table.Column<bool>(nullable: false),
                    IsUnderContract = table.Column<bool>(nullable: false),
                    IsClearToClose = table.Column<bool>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklist", x => x.ChecklistId);
                });

            migrationBuilder.CreateTable(
                name: "ClosingRep",
                columns: table => new
                {
                    ClosingRepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosingRep", x => x.ClosingRepId);
                });

            migrationBuilder.CreateTable(
                name: "LoanOfficer",
                columns: table => new
                {
                    LoanOfficerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOfficer", x => x.LoanOfficerId);
                });

            migrationBuilder.CreateTable(
                name: "Realtor",
                columns: table => new
                {
                    RealtorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realtor", x => x.RealtorId);
                });



            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SocialSecurityNumber = table.Column<int>(nullable: false),
                    TypeOfClient = table.Column<string>(nullable: true),
                    ClosingDate = table.Column<DateTime>(type: "date", nullable: true),
                    DepositAmount = table.Column<double>(nullable: false),
                    ApprovedAmount = table.Column<double>(nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "date", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "date", nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    RealtorId = table.Column<int>(nullable: false),
                    LoanOfficerId = table.Column<int>(nullable: false),
                    ClosingRepId = table.Column<int>(nullable: false),
                    ChecklistId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklist",
                        principalColumn: "ChecklistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_ClosingRep_ClosingRepId",
                        column: x => x.ClosingRepId,
                        principalTable: "ClosingRep",
                        principalColumn: "ClosingRepId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_LoanOfficer_LoanOfficerId",
                        column: x => x.LoanOfficerId,
                        principalTable: "LoanOfficer",
                        principalColumn: "LoanOfficerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Realtor_RealtorId",
                        column: x => x.RealtorId,
                        principalTable: "Realtor",
                        principalColumn: "RealtorId",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressId",
                table: "Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ChecklistId",
                table: "Client",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClosingRepId",
                table: "Client",
                column: "ClosingRepId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdentityUserId",
                table: "Client",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_LoanOfficerId",
                table: "Client",
                column: "LoanOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RealtorId",
                table: "Client",
                column: "RealtorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "Client");

           

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Checklist");

            migrationBuilder.DropTable(
                name: "ClosingRep");

          

            migrationBuilder.DropTable(
                name: "LoanOfficer");

            migrationBuilder.DropTable(
                name: "Realtor");
        }
    }
}
