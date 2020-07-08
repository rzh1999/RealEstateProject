using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Data.Migrations
{
    public partial class addFkToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e71af0-8e3b-4813-bf50-c92757aeefaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d189acb-7d58-4eba-973d-d917914d47b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eabc57d-5ead-405c-9483-5d53260123f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf34fb74-4e41-4032-83ec-b8a7e3aa6f64");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Realtor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "LoanOfficer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "ClosingRep",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_Realtor_IdentityUserId",
                table: "Realtor",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanOfficer_IdentityUserId",
                table: "LoanOfficer",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingRep_IdentityUserId",
                table: "ClosingRep",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRep_AspNetUsers_IdentityUserId",
                table: "ClosingRep",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanOfficer_AspNetUsers_IdentityUserId",
                table: "LoanOfficer",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Realtor_AspNetUsers_IdentityUserId",
                table: "Realtor",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRep_AspNetUsers_IdentityUserId",
                table: "ClosingRep");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanOfficer_AspNetUsers_IdentityUserId",
                table: "LoanOfficer");

            migrationBuilder.DropForeignKey(
                name: "FK_Realtor_AspNetUsers_IdentityUserId",
                table: "Realtor");

            migrationBuilder.DropIndex(
                name: "IX_Realtor_IdentityUserId",
                table: "Realtor");

            migrationBuilder.DropIndex(
                name: "IX_LoanOfficer_IdentityUserId",
                table: "LoanOfficer");

            migrationBuilder.DropIndex(
                name: "IX_ClosingRep_IdentityUserId",
                table: "ClosingRep");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "323cf86e-aff1-4b6f-b9e6-1087f1f542af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a9e383e-374d-47e1-a09a-52ba4844b829");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af96485f-55f5-46e1-9a6c-35ed8ac925b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2558ac8-8176-4454-a3c8-0a6bd3bd36e4");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Realtor");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "LoanOfficer");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "ClosingRep");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d189acb-7d58-4eba-973d-d917914d47b9", "a26b1afc-3b4d-45c2-b93b-aaf82906dbae", "Client", "CLIENT" },
                    { "19e71af0-8e3b-4813-bf50-c92757aeefaa", "b7de08ae-800e-4651-96fa-130291a53d5b", "Realtor", "REALTOR" },
                    { "bf34fb74-4e41-4032-83ec-b8a7e3aa6f64", "83355185-1b0b-4579-9444-5faa453b4461", "LoanOfficer", "LOANOFFICER" },
                    { "6eabc57d-5ead-405c-9483-5d53260123f2", "325c5997-7a6c-4bae-b598-729a7636eca4", "Closing", "CLOSING" }
                });
        }
    }
}
