using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetWebAPI.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Rendez_Vous");

            migrationBuilder.AddColumn<int>(
                name: "Rendez_vousid",
                table: "Consultation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_Rendez_vousid",
                table: "Consultation",
                column: "Rendez_vousid");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Rendez_Vous_Rendez_vousid",
                table: "Consultation",
                column: "Rendez_vousid",
                principalTable: "Rendez_Vous",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Rendez_Vous_Rendez_vousid",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_Rendez_vousid",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "Rendez_vousid",
                table: "Consultation");

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Rendez_Vous",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
