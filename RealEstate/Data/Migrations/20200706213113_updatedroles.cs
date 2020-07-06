using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Data.Migrations
{
    public partial class updatedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55336bc5-70c9-4bcf-817a-2f4530e9ec64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43d231f3-1da0-44ff-8b4c-8cd793bf79a9", "c66efb18-ab2a-4e4e-bde1-7de924740fad", "Client", "CLIENT" },
                    { "31a15852-8791-4af0-a390-821b7c6c696f", "b1a5c13b-da85-4860-bf1c-47781b71f3f7", "Realtor", "REALTOR" },
                    { "a543736e-9275-4b89-9947-fd6d2577ac43", "3709563d-cc6e-4270-9c21-4fba09ad1dcd", "LoanOfficer", "LOANOFFICER" },
                    { "a74f548f-566a-411e-af0c-9dc9efe25915", "6eb58d5f-0e9a-4132-bffa-d9684d59a190", "Closing", "CLOSING" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31a15852-8791-4af0-a390-821b7c6c696f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43d231f3-1da0-44ff-8b4c-8cd793bf79a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a543736e-9275-4b89-9947-fd6d2577ac43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a74f548f-566a-411e-af0c-9dc9efe25915");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55336bc5-70c9-4bcf-817a-2f4530e9ec64", "5490e7d2-c40e-4f8e-8ff3-8b0d4cd939f6", "Admin", "ADMIN" });
        }
    }
}
