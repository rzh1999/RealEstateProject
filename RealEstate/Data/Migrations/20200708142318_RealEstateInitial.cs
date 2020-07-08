using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Data.Migrations
{
    public partial class RealEstateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "f9f65061-73e9-48aa-85bd-1035502744fa", "e61a8210-85c3-4f33-9235-43ac4a09abe7", "Client", "CLIENT" },
                    { "3b74f624-35df-4d2c-b9dc-91ffd4d0f129", "29c9d091-70df-4d3e-b003-d7f375ccf786", "Realtor", "REALTOR" },
                    { "d627a552-8041-475a-9359-a5966d778925", "3c5e4e2e-4954-4e1b-aa25-933fa7d14d45", "LoanOfficer", "LOANOFFICER" },
                    { "4a85c849-43bb-454c-a934-f10aa75401ca", "1def14c4-cb8a-41bb-a6f6-7b61046ab156", "Closing", "CLOSING" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b74f624-35df-4d2c-b9dc-91ffd4d0f129");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a85c849-43bb-454c-a934-f10aa75401ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d627a552-8041-475a-9359-a5966d778925");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9f65061-73e9-48aa-85bd-1035502744fa");

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
    }
}
