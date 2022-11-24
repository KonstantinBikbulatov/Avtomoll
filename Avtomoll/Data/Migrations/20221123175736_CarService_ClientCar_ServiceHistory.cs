using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Data.Migrations
{
    public partial class CarService_ClientCar_ServiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    CarServiceId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<string>(nullable: true),
                    ClosingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.CarServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ClientCars",
                columns: table => new
                {
                    ClientCarId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCars", x => x.ClientCarId);
                    table.ForeignKey(
                        name: "FK_ClientCars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicesHistory",
                columns: table => new
                {
                    ServiceHistoryId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<long>(nullable: true),
                    CarServiceId = table.Column<Guid>(nullable: true),
                    ClientCarId = table.Column<Guid>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    TypeCar = table.Column<string>(nullable: true),
                    NameClient = table.Column<string>(nullable: true),
                    PhoneClient = table.Column<string>(nullable: true),
                    CarBrand = table.Column<string>(nullable: true),
                    OrderTime = table.Column<TimeSpan>(nullable: false),
                    VisitTime = table.Column<TimeSpan>(nullable: false),
                    PriceService = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesHistory", x => x.ServiceHistoryId);
                    table.ForeignKey(
                        name: "FK_ServicesHistory_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "CarServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesHistory_ClientCars_ClientCarId",
                        column: x => x.ClientCarId,
                        principalTable: "ClientCars",
                        principalColumn: "ClientCarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesHistory_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCars_UserId",
                table: "ClientCars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesHistory_CarServiceId",
                table: "ServicesHistory",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesHistory_ClientCarId",
                table: "ServicesHistory",
                column: "ClientCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesHistory_ServiceId",
                table: "ServicesHistory",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesHistory_UserId",
                table: "ServicesHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesHistory");

            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "ClientCars");
        }
    }
}
