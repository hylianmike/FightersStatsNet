using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersStatsNet.Data.Migrations
{
    public partial class renamecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Game",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "AttackID",
                table: "Attacks",
                newName: "AttackId");

            migrationBuilder.RenameColumn(
                name: "AttackName",
                table: "Attacks",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Game",
                newName: "GameID");

            migrationBuilder.RenameColumn(
                name: "AttackId",
                table: "Attacks",
                newName: "AttackID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attacks",
                newName: "AttackName");
        }
    }
}
