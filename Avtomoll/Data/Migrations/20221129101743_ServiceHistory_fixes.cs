using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Data.Migrations
{
    public partial class ServiceHistory_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesHistory_Services_ServiceId",
                table: "ServicesHistory");

            migrationBuilder.DropIndex(
                name: "IX_ServicesHistory_ServiceId",
                table: "ServicesHistory");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServicesHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VisitTime",
                table: "ServicesHistory",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "PriceService",
                table: "ServicesHistory",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "ServicesHistory",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<long>(
                name: "OrderNumber",
                table: "ServicesHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "ServicesHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services",
                table: "ServicesHistory");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "VisitTime",
                table: "ServicesHistory",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "PriceService",
                table: "ServicesHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OrderTime",
                table: "ServicesHistory",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "ServicesHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "ServicesHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesHistory_ServiceId",
                table: "ServicesHistory",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesHistory_Services_ServiceId",
                table: "ServicesHistory",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
