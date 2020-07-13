using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class init : Migration
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
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosingRep", x => x.ClosingRepId);
                    table.ForeignKey(
                        name: "FK_ClosingRep_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOfficer", x => x.LoanOfficerId);
                    table.ForeignKey(
                        name: "FK_LoanOfficer_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Realtor",
                columns: table => new
                {
                    RealtorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<int>(nullable: false),
                    AgentName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realtor", x => x.RealtorId);
                    table.ForeignKey(
                        name: "FK_Realtor_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    RealtorId = table.Column<int>(nullable: true),
                    LoanOfficerId = table.Column<int>(nullable: true),
                    ClosingRepId = table.Column<int>(nullable: true),
                    ChecklistId = table.Column<int>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklist",
                        principalColumn: "ChecklistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_ClosingRep_ClosingRepId",
                        column: x => x.ClosingRepId,
                        principalTable: "ClosingRep",
                        principalColumn: "ClosingRepId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Realtor_RealtorId",
                        column: x => x.RealtorId,
                        principalTable: "Realtor",
                        principalColumn: "RealtorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84940990-4b8a-4f6b-b4e9-c6f4ed9f2753", "e4d2927a-24c5-4147-8a2a-dcab6e7cdf92", "Client", "CLIENT" },
                    { "ceec2ddc-40f8-4783-8de9-219c13377c0a", "b1efbea9-8e06-4deb-86bf-447205b41443", "Realtor", "REALTOR" },
                    { "ff776ad4-94f0-442a-818e-5a69044ad1f7", "dc674558-da2d-4aee-9144-86165ca4587e", "LoanOfficer", "LOANOFFICER" },
                    { "74869eb1-589c-4662-8c17-0b5a18b73daf", "9c67cf15-9b5b-4836-9945-02d0f189a856", "Closing", "CLOSING" },
                    { "ec6467b0-062b-4b71-b425-89ee1ac5be6b", "0b914fa0-99e7-4e76-991e-ed5de8353efd", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRep_IdentityUserId",
                table: "ClosingRep",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanOfficer_IdentityUserId",
                table: "LoanOfficer",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Realtor_IdentityUserId",
                table: "Realtor",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
