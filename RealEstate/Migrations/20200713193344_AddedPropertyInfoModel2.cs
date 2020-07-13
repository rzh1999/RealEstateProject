using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class AddedPropertyInfoModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bb74a9e-f6a1-4aee-af48-0f67283abd9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ea42632-3fc9-43c9-b5af-ad40df8a1208");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "637b978a-7557-448e-a696-8083d4386cd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d64e59b-1397-4623-92bb-8611a4bdb9bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a95f59e6-c6fe-4341-8b77-acc6b8e6862e");

            migrationBuilder.CreateTable(
                name: "PropertyInfo",
                columns: table => new
                {
                    PropertyInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquareFeet = table.Column<int>(nullable: false),
                    Beds = table.Column<int>(nullable: false),
                    Baths = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInfo", x => x.PropertyInfoId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57b7659d-36b7-4ca0-a901-b75f5f80e918", "88c28e48-96a4-4570-a67d-97acb69d46dd", "Client", "CLIENT" },
                    { "5d0fe82c-998b-45a1-84f3-7a28ddbf50a3", "4d5aa7ed-4906-4739-905d-2a0349dcc552", "Realtor", "REALTOR" },
                    { "88693854-c067-46aa-83ab-5a56ec8024ad", "6c9c2d33-570a-4435-b5bb-dfa586b5d325", "LoanOfficer", "LOANOFFICER" },
                    { "cec30a4c-d2cd-43b1-b301-74e0fd46ee97", "e9a17a14-b9b6-462a-9526-932ec26d854b", "Closing", "CLOSING" },
                    { "07747788-c709-4c05-885c-23efd41c215f", "61b6d893-67a8-4304-9182-4c8a03aa74de", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyInfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07747788-c709-4c05-885c-23efd41c215f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57b7659d-36b7-4ca0-a901-b75f5f80e918");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d0fe82c-998b-45a1-84f3-7a28ddbf50a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88693854-c067-46aa-83ab-5a56ec8024ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cec30a4c-d2cd-43b1-b301-74e0fd46ee97");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bb74a9e-f6a1-4aee-af48-0f67283abd9d", "58992c78-74f7-47aa-99d3-edaa6bebad63", "Client", "CLIENT" },
                    { "7d64e59b-1397-4623-92bb-8611a4bdb9bd", "8dfa14e4-41cc-477e-8b28-74869113f19d", "Realtor", "REALTOR" },
                    { "637b978a-7557-448e-a696-8083d4386cd6", "3264c883-6959-46ca-b75a-ae8755606410", "LoanOfficer", "LOANOFFICER" },
                    { "a95f59e6-c6fe-4341-8b77-acc6b8e6862e", "84887e6b-0d92-431c-b628-384277207389", "Closing", "CLOSING" },
                    { "4ea42632-3fc9-43c9-b5af-ad40df8a1208", "6552e259-4819-452b-b490-82f3a7d3fb90", "Admin", "ADMIN" }
                });
        }
    }
}
