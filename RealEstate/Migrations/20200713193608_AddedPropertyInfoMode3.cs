using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class AddedPropertyInfoMode3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "Address",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PropertyInfoId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Address_PropertyInfoId",
                table: "Address",
                column: "PropertyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_PropertyInfo_PropertyInfoId",
                table: "Address",
                column: "PropertyInfoId",
                principalTable: "PropertyInfo",
                principalColumn: "PropertyInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_PropertyInfo_PropertyInfoId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_PropertyInfoId",
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

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PropertyInfoId",
                table: "Address");

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
    }
}
