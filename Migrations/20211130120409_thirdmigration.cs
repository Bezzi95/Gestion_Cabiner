using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetWebAPI.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Consult = table.Column<DateTime>(type: "datetime2", nullable: false),
                    resultat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patientid = table.Column<int>(type: "int", nullable: false),
                    Medecinid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultation_Medcines_Medecinid",
                        column: x => x.Medecinid,
                        principalTable: "Medcines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultation_Patients_Patientid",
                        column: x => x.Patientid,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_Medecinid",
                table: "Consultation",
                column: "Medecinid");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_Patientid",
                table: "Consultation",
                column: "Patientid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultation");
        }
    }
}
