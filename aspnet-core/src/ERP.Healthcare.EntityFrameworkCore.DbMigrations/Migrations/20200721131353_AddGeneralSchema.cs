using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Healthcare.Migrations
{
    public partial class AddGeneralSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Addresses_AddressId",
                schema: "Doctor",
                table: "Memberships");

            migrationBuilder.EnsureSchema(
                name: "General");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "States",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Countries",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Cities",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresses",
                newSchema: "General");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                schema: "Doctor",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Addresses_AddressId",
                schema: "Doctor",
                table: "Memberships",
                column: "AddressId",
                principalSchema: "General",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Addresses_AddressId",
                schema: "Doctor",
                table: "Memberships");

            migrationBuilder.RenameTable(
                name: "States",
                schema: "General",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Countries",
                schema: "General",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "General",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "General",
                newName: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                schema: "Doctor",
                table: "Memberships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Addresses_AddressId",
                schema: "Doctor",
                table: "Memberships",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
