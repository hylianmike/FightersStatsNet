using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersStatsNet.Data.Migrations
{
    public partial class CreateFightersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    FighterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    Strengths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weaknesses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.FighterId);
                    table.ForeignKey(
                        name: "FK_Fighters_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    AttackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fighter = table.Column<int>(type: "int", nullable: false),
                    FighterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.AttackID);
                    table.ForeignKey(
                        name: "FK_Attacks_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "FighterId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_FighterId",
                table: "Attacks",
                column: "FighterId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_GameID",
                table: "Fighters",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "Fighters");
        }
    }
}
