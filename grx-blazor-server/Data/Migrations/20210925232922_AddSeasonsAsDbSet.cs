using Microsoft.EntityFrameworkCore.Migrations;

namespace grx_blazor_server.Data.Migrations
{
    public partial class AddSeasonsAsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Season_SeasonUid",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Leagues_LeagueUid",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.RenameIndex(
                name: "IX_Season_LeagueUid",
                table: "Seasons",
                newName: "IX_Seasons_LeagueUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "SeasonUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Seasons_SeasonUid",
                table: "Game",
                column: "SeasonUid",
                principalTable: "Seasons",
                principalColumn: "SeasonUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Leagues_LeagueUid",
                table: "Seasons",
                column: "LeagueUid",
                principalTable: "Leagues",
                principalColumn: "LeagueUid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Seasons_SeasonUid",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Leagues_LeagueUid",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.RenameIndex(
                name: "IX_Seasons_LeagueUid",
                table: "Season",
                newName: "IX_Season_LeagueUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "SeasonUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Season_SeasonUid",
                table: "Game",
                column: "SeasonUid",
                principalTable: "Season",
                principalColumn: "SeasonUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Leagues_LeagueUid",
                table: "Season",
                column: "LeagueUid",
                principalTable: "Leagues",
                principalColumn: "LeagueUid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
