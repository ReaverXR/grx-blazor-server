using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace grx_blazor_server.Data.Migrations
{
    public partial class AddLeagueFKToLeagueNights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueNight_Leagues_LeagueUid",
                table: "LeagueNight");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeagueUid",
                table: "LeagueNight",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueNight_Leagues_LeagueUid",
                table: "LeagueNight",
                column: "LeagueUid",
                principalTable: "Leagues",
                principalColumn: "LeagueUid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueNight_Leagues_LeagueUid",
                table: "LeagueNight");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeagueUid",
                table: "LeagueNight",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueNight_Leagues_LeagueUid",
                table: "LeagueNight",
                column: "LeagueUid",
                principalTable: "Leagues",
                principalColumn: "LeagueUid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
