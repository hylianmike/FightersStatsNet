using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersStatsNet.Data.Migrations
{
    public partial class fixanythingthatwentwronghopefully : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_Fighters_FighterId",
                table: "Attacks");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_FighterId",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "Fighter",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "FighterId",
                table: "Attacks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fighter",
                table: "Attacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FighterId",
                table: "Attacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_FighterId",
                table: "Attacks",
                column: "FighterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_Fighters_FighterId",
                table: "Attacks",
                column: "FighterId",
                principalTable: "Fighters",
                principalColumn: "FighterId");
        }
    }
}
