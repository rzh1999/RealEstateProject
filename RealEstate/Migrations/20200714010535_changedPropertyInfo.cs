using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class changedPropertyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_PropertyInfo_PropertyInfoId",
                table: "Address");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "653a5f46-e056-46a9-bb55-4a14efaed41f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71804da4-dcf1-46d7-9647-79994c16ba0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "924b1ce9-076d-4477-925e-bce8216dc594");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d020494a-c79d-47b6-96b2-4e9697e9c78d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d29b60cb-ad6a-43e0-a2b5-112541853da3");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyInfoId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58dbb2e9-b8ec-4e62-8bc8-7cda8e4da252", "4d74e07b-014d-4fe0-bf82-64a3ea617e6f", "Client", "CLIENT" },
                    { "34edae61-d757-41f3-9358-65fa97af56e0", "1aa45af1-d202-4a9f-8934-14780f48d996", "Realtor", "REALTOR" },
                    { "07edcc73-b07f-429f-9ea3-6d75b18429d6", "7f650dc9-ad0b-4cfa-ab12-cca00e233be5", "LoanOfficer", "LOANOFFICER" },
                    { "e2eca608-400f-4e19-bc28-323937d921c6", "c94323a7-9ab3-4a78-b2bf-2a8a3235d400", "Closing", "CLOSING" },
                    { "f5ff1df4-25ed-4db9-a429-156cd226b673", "429b967a-ea4a-417e-b086-791c81378261", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_PropertyInfo_PropertyInfoId",
                table: "Address",
                column: "PropertyInfoId",
                principalTable: "PropertyInfo",
                principalColumn: "PropertyInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_PropertyInfo_PropertyInfoId",
                table: "Address");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07edcc73-b07f-429f-9ea3-6d75b18429d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34edae61-d757-41f3-9358-65fa97af56e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58dbb2e9-b8ec-4e62-8bc8-7cda8e4da252");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2eca608-400f-4e19-bc28-323937d921c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5ff1df4-25ed-4db9-a429-156cd226b673");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyInfoId",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d29b60cb-ad6a-43e0-a2b5-112541853da3", "33e07d4f-7b93-4e19-aff2-e1fcebe940f7", "Client", "CLIENT" },
                    { "924b1ce9-076d-4477-925e-bce8216dc594", "0458a777-3830-4073-b9ea-f65f7c888aea", "Realtor", "REALTOR" },
                    { "653a5f46-e056-46a9-bb55-4a14efaed41f", "e3de725f-2793-4034-9d9d-65e3d88d0f43", "LoanOfficer", "LOANOFFICER" },
                    { "71804da4-dcf1-46d7-9647-79994c16ba0f", "134e76a7-6111-4863-b622-4c2add12fcf0", "Closing", "CLOSING" },
                    { "d020494a-c79d-47b6-96b2-4e9697e9c78d", "f8bd155f-c174-4f63-8f54-a5f63954e12e", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_PropertyInfo_PropertyInfoId",
                table: "Address",
                column: "PropertyInfoId",
                principalTable: "PropertyInfo",
                principalColumn: "PropertyInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
