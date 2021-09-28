using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace grx_blazor_server.Data.Migrations
{
    public partial class AddBasicDomainObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwningUserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueUid);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerUid);
                    table.ForeignKey(
                        name: "FK_Players_Leagues_LeagueUid",
                        column: x => x.LeagueUid,
                        principalTable: "Leagues",
                        principalColumn: "LeagueUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxGamesPerPlayer = table.Column<int>(type: "int", nullable: false),
                    LeagueUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonUid);
                    table.ForeignKey(
                        name: "FK_Season_Leagues_LeagueUid",
                        column: x => x.LeagueUid,
                        principalTable: "Leagues",
                        principalColumn: "LeagueUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameUid);
                    table.ForeignKey(
                        name: "FK_Game_Season_SeasonUid",
                        column: x => x.SeasonUid,
                        principalTable: "Season",
                        principalColumn: "SeasonUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameResult",
                columns: table => new
                {
                    GameResultUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Faction = table.Column<byte>(type: "tinyint", nullable: false),
                    TieBreakerWin = table.Column<bool>(type: "bit", nullable: false),
                    GameUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResult", x => x.GameResultUid);
                    table.ForeignKey(
                        name: "FK_GameResult_Game_GameUid",
                        column: x => x.GameUid,
                        principalTable: "Game",
                        principalColumn: "GameUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameResult_Players_PlayerUid",
                        column: x => x.PlayerUid,
                        principalTable: "Players",
                        principalColumn: "PlayerUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_SeasonUid",
                table: "Game",
                column: "SeasonUid");

            migrationBuilder.CreateIndex(
                name: "IX_GameResult_GameUid",
                table: "GameResult",
                column: "GameUid");

            migrationBuilder.CreateIndex(
                name: "IX_GameResult_PlayerUid",
                table: "GameResult",
                column: "PlayerUid");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LeagueUid",
                table: "Players",
                column: "LeagueUid");

            migrationBuilder.CreateIndex(
                name: "IX_Season_LeagueUid",
                table: "Season",
                column: "LeagueUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResult");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
