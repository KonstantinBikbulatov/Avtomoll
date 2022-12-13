using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Migrations
{
    public partial class fresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "ServicesHistory");

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    ClientServiceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<long>(nullable: true),
                    ServiceHistoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => x.ClientServiceId);
                    table.ForeignKey(
                        name: "FK_ClientServices_ServicesHistory_ServiceHistoryId",
                        column: x => x.ServiceHistoryId,
                        principalTable: "ServicesHistory",
                        principalColumn: "ServiceHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceHistoryId",
                table: "ClientServices",
                column: "ServiceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "ServicesHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
