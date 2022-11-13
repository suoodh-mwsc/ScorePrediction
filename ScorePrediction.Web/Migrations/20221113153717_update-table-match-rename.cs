using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScorePrediction.Web.Migrations
{
    public partial class updatetablematchrename : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeTeamId1",
                table: "Matches",
                newName: "HomeTeamId",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "AwayTeamId1",
                table: "Matches",
                newName: "AwayTeamId",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeTeamId",
                table: "Matches",
                newName: "HomeTeamId1",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "AwayTeamId",
                table: "Matches",
                newName: "AwayTeamId1",
                schema: "dbo");
        }
    }
}
