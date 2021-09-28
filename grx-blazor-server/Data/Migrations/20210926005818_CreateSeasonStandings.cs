using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace grx_blazor_server.Data.Migrations
{
    public partial class CreateSeasonStandings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Score",
                table: "GameResult",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PlayerSeason",
                columns: table => new
                {
                    PlayersPlayerUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonsSeasonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeason", x => new { x.PlayersPlayerUid, x.SeasonsSeasonUid });
                    table.ForeignKey(
                        name: "FK_PlayerSeason_Players_PlayersPlayerUid",
                        column: x => x.PlayersPlayerUid,
                        principalTable: "Players",
                        principalColumn: "PlayerUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSeason_Seasons_SeasonsSeasonUid",
                        column: x => x.SeasonsSeasonUid,
                        principalTable: "Seasons",
                        principalColumn: "SeasonUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeason_SeasonsSeasonUid",
                table: "PlayerSeason",
                column: "SeasonsSeasonUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSeason");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "GameResult",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
