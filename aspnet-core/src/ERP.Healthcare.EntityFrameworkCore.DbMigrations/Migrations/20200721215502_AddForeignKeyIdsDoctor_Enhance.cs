using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Healthcare.Migrations
{
    public partial class AddForeignKeyIdsDoctor_Enhance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorSpecialties_DoctorTitleId",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorTitles_DoctorTitleId1",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorTitleId1",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorTitleId1",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorSpecialtyId",
                schema: "Doctor",
                table: "Doctors",
                column: "DoctorSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorSpecialties_DoctorSpecialtyId",
                schema: "Doctor",
                table: "Doctors",
                column: "DoctorSpecialtyId",
                principalSchema: "Doctor",
                principalTable: "DoctorSpecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorTitles_DoctorTitleId",
                schema: "Doctor",
                table: "Doctors",
                column: "DoctorTitleId",
                principalSchema: "Doctor",
                principalTable: "DoctorTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorSpecialties_DoctorSpecialtyId",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorTitles_DoctorTitleId",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorSpecialtyId",
                schema: "Doctor",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "DoctorTitleId1",
                schema: "Doctor",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorTitleId1",
                schema: "Doctor",
                table: "Doctors",
                column: "DoctorTitleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorSpecialties_DoctorTitleId",
                schema: "Doctor",
                table: "Doctors",
                column: "DoctorTitleId",
                principalSchema: "Doctor",
                principalTable: "DoctorSpecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorTitles_DoctorTitleId1",
                schema: "Doctor",
                table: "Doctors",
                column: "DoctorTitleId1",
                principalSchema: "Doctor",
                principalTable: "DoctorTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
