using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersStatsNet.Data.Migrations
{
    public partial class addfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Game_GameID",
                table: "Fighters");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Fighters",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Fighters_GameID",
                table: "Fighters",
                newName: "IX_Fighters_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Fighters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Game_GameId",
                table: "Fighters",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Game_GameId",
                table: "Fighters");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Fighters",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Fighters_GameId",
                table: "Fighters",
                newName: "IX_Fighters_GameID");

            migrationBuilder.AlterColumn<int>(
                name: "GameID",
                table: "Fighters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Game_GameID",
                table: "Fighters",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID");
        }
    }
}
