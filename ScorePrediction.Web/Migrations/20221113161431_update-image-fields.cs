using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScorePrediction.Web.Migrations
{
    public partial class updateimagefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tournaments");
        }
    }
}
