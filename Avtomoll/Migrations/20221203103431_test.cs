using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomoll.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
