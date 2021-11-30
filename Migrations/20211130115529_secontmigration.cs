using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetWebAPI.Migrations
{
    public partial class secontmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medcines_Patients_Patientid",
                table: "Medcines");

            migrationBuilder.DropForeignKey(
                name: "FK_Rendez_Vous_Patients_Patientid",
                table: "Rendez_Vous");

            migrationBuilder.DropIndex(
                name: "IX_Medcines_Patientid",
                table: "Medcines");

            migrationBuilder.DropColumn(
                name: "CNE",
                table: "Rendez_Vous");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Rendez_Vous");

            migrationBuilder.DropColumn(
                name: "Patientid",
                table: "Medcines");

            migrationBuilder.AlterColumn<int>(
                name: "Patientid",
                table: "Rendez_Vous",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendez_Vous_Patients_Patientid",
                table: "Rendez_Vous",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendez_Vous_Patients_Patientid",
                table: "Rendez_Vous");

            migrationBuilder.AlterColumn<int>(
                name: "Patientid",
                table: "Rendez_Vous",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CNE",
                table: "Rendez_Vous",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Rendez_Vous",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Patientid",
                table: "Medcines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medcines_Patientid",
                table: "Medcines",
                column: "Patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_Medcines_Patients_Patientid",
                table: "Medcines",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendez_Vous_Patients_Patientid",
                table: "Rendez_Vous",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
