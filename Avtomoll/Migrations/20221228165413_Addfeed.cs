using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Migrations
{
    public partial class Addfeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FeedBacks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FeedBacks");
        }
    }
}
