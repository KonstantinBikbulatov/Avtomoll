using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Migrations
{
    public partial class addmig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "FeedBacks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "FeedBacks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "FeedBacks");
        }
    }
}
