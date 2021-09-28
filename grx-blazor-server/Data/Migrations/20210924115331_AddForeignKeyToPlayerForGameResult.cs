using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace grx_blazor_server.Data.Migrations
{
    public partial class AddForeignKeyToPlayerForGameResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Season_SeasonUid",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameResult_Game_GameUid",
                table: "GameResult");

            migrationBuilder.DropForeignKey(
                name: "FK_GameResult_Players_PlayerUid",
                table: "GameResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Leagues_LeagueUid",
                table: "Season");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeagueUid",
                table: "Season",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerUid",
                table: "GameResult",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GameUid",
                table: "GameResult",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SeasonUid",
                table: "Game",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Season_SeasonUid",
                table: "Game",
                column: "SeasonUid",
                principalTable: "Season",
                principalColumn: "SeasonUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResult_Game_GameUid",
                table: "GameResult",
                column: "GameUid",
                principalTable: "Game",
                principalColumn: "GameUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResult_Players_PlayerUid",
                table: "GameResult",
                column: "PlayerUid",
                principalTable: "Players",
                principalColumn: "PlayerUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Leagues_LeagueUid",
                table: "Season",
                column: "LeagueUid",
                principalTable: "Leagues",
                principalColumn: "LeagueUid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Season_SeasonUid",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameResult_Game_GameUid",
                table: "GameResult");

            migrationBuilder.DropForeignKey(
                name: "FK_GameResult_Players_PlayerUid",
                table: "GameResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Leagues_LeagueUid",
                table: "Season");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeagueUid",
                table: "Season",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerUid",
                table: "GameResult",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameUid",
                table: "GameResult",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SeasonUid",
                table: "Game",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Season_SeasonUid",
                table: "Game",
                column: "SeasonUid",
                principalTable: "Season",
                principalColumn: "SeasonUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResult_Game_GameUid",
                table: "GameResult",
                column: "GameUid",
                principalTable: "Game",
                principalColumn: "GameUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResult_Players_PlayerUid",
                table: "GameResult",
                column: "PlayerUid",
                principalTable: "Players",
                principalColumn: "PlayerUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Leagues_LeagueUid",
                table: "Season",
                column: "LeagueUid",
                principalTable: "Leagues",
                principalColumn: "LeagueUid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
