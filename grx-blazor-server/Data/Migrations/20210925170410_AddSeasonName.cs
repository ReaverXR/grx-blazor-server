using Microsoft.EntityFrameworkCore.Migrations;

namespace grx_blazor_server.Data.Migrations
{
    public partial class AddSeasonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Season",
                newName: "StartDateUtc");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Season",
                newName: "EndDateUtc");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Season",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Season");

            migrationBuilder.RenameColumn(
                name: "StartDateUtc",
                table: "Season",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndDateUtc",
                table: "Season",
                newName: "EndDate");
        }
    }
}
