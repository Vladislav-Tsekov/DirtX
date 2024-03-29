using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class TrailerSeedDataAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Trailers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "NEPTUN - Trailer for One Motorcycle");

            migrationBuilder.UpdateData(
                table: "Trailers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "MGT - Trailer for Two Motorcycles");

            migrationBuilder.UpdateData(
                table: "Trailers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "FELK - Trailer for Three Motorcycles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trailers");
        }
    }
}
