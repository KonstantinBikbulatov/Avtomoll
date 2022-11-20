using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Data.Migrations
{
    public partial class AddServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupServices",
                columns: table => new
                {
                    GroupServiceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupServices", x => x.GroupServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NativeCar = table.Column<string>(nullable: true),
                    ForeignCar = table.Column<string>(nullable: true),
                    LeadTime = table.Column<string>(nullable: true),
                    GroupServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_GroupServices_GroupServiceId",
                        column: x => x.GroupServiceId,
                        principalTable: "GroupServices",
                        principalColumn: "GroupServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_GroupServiceId",
                table: "Services",
                column: "GroupServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "GroupServices");
        }
    }
}
