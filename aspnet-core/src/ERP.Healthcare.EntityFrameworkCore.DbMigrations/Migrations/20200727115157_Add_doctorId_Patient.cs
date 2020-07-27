using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Healthcare.Migrations
{
    public partial class Add_doctorId_Patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                schema: "Patient",
                table: "Patient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorId",
                schema: "Patient",
                table: "Patient",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctors_DoctorId",
                schema: "Patient",
                table: "Patient",
                column: "DoctorId",
                principalSchema: "Doctor",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctors_DoctorId",
                schema: "Patient",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorId",
                schema: "Patient",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                schema: "Patient",
                table: "Patient");
        }
    }
}
