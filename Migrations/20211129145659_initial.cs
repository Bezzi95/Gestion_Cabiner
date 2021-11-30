using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetWebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Patientid",
                table: "Rendez_Vous",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rendez_Vous_Patientid",
                table: "Rendez_Vous",
                column: "Patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendez_Vous_Patients_Patientid",
                table: "Rendez_Vous",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendez_Vous_Patients_Patientid",
                table: "Rendez_Vous");

            migrationBuilder.DropIndex(
                name: "IX_Rendez_Vous_Patientid",
                table: "Rendez_Vous");

            migrationBuilder.DropColumn(
                name: "Patientid",
                table: "Rendez_Vous");
        }
    }
}
