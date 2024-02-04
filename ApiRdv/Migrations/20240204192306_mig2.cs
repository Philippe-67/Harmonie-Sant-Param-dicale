using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRdv.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RendezVous",
                table: "RendezVous");

            migrationBuilder.RenameTable(
                name: "RendezVous",
                newName: "Rdvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rdvs",
                table: "Rdvs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rdvs",
                table: "Rdvs");

            migrationBuilder.RenameTable(
                name: "Rdvs",
                newName: "RendezVous");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RendezVous",
                table: "RendezVous",
                column: "Id");
        }
    }
}
