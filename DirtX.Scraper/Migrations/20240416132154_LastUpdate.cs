using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Scraper.Migrations
{
    public partial class LastUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScraperInfo",
                table: "ScraperInfo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScraperInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ManufactureYear",
                table: "Years",
                type: "int",
                nullable: false,
                comment: "Motorcycle's Year of manufacture",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastRunDate",
                table: "ScraperInfo",
                type: "datetime2",
                nullable: false,
                comment: "The last known date when the scraper was used to crawl the web.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Makes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Motorcycle's Make - Manufacturer's Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScraperInfo",
                table: "ScraperInfo",
                column: "LastRunDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScraperInfo",
                table: "ScraperInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ManufactureYear",
                table: "Years",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Motorcycle's Year of manufacture");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastRunDate",
                table: "ScraperInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The last known date when the scraper was used to crawl the web.");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScraperInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Makes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Motorcycle's Make - Manufacturer's Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScraperInfo",
                table: "ScraperInfo",
                column: "Id");
        }
    }
}
