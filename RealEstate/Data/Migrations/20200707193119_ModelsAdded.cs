using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Data.Migrations
{
    public partial class ModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "0b128b59-9e67-4504-a265-592a31c0d37c", "4c07c10f-56e1-431e-9ef4-31f2ceceb2cc", "Client", "CLIENT" },
                    { "22812158-3509-4ef1-98e0-7201b2e20234", "05442e5a-d877-4921-964e-01553ea27121", "Realtor", "REALTOR" },
                    { "01035c93-e8f3-4013-9e83-ce5b9fe89378", "38e86267-d7fa-4be2-8218-f71d3c504651", "LoanOfficer", "LOANOFFICER" },
                    { "1c1da43a-2ecb-4e47-9c1c-10a153a45780", "9f1bbc7d-72dd-44f5-8d95-a64c5f2024d3", "Closing", "CLOSING" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01035c93-e8f3-4013-9e83-ce5b9fe89378");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b128b59-9e67-4504-a265-592a31c0d37c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c1da43a-2ecb-4e47-9c1c-10a153a45780");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22812158-3509-4ef1-98e0-7201b2e20234");

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
    }
}
