using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class LatLngType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50322ab5-0dd3-4878-920d-89888af90a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ce22413-1d00-44c2-a8ac-139754034b27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f4e3a3e-c471-485c-92c9-4efa0b8db120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e7bce04-b2ad-4256-894b-b53c125126e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbec1f5d-9d97-4a8d-9511-0971266daa14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                 
                    { "308d812d-a5c5-4bab-97eb-db97cbc8c807", "3186a637-eac6-48a0-99bd-c83ff64a7c9e", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308d812d-a5c5-4bab-97eb-db97cbc8c807");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1f2e98-6561-4b8a-bad9-9e0f08f03018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65168fa4-296e-451d-8828-fec7647ac7db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbcff867-7617-4dc9-b504-81b292a87895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f6fdd3-713a-407f-93ea-2f2c8ab9c7ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e7bce04-b2ad-4256-894b-b53c125126e8", "ab98c6a5-b14f-43e1-bc38-2afafb7432ab", "Client", "CLIENT" },
                    { "6ce22413-1d00-44c2-a8ac-139754034b27", "71b664e3-09cc-47f2-b411-fcc67985004d", "Realtor", "REALTOR" },
                    { "dbec1f5d-9d97-4a8d-9511-0971266daa14", "dd69bc33-fdaf-45a9-a9a7-729a437f0778", "LoanOfficer", "LOANOFFICER" },
                    { "6f4e3a3e-c471-485c-92c9-4efa0b8db120", "e8202e38-6bc6-4ee7-b377-d424020218af", "Closing", "CLOSING" },
                    { "50322ab5-0dd3-4878-920d-89888af90a38", "1acdc5c6-efe6-4b67-984d-6c167b070f1e", "Admin", "ADMIN" }
                });
        }
    }
}
