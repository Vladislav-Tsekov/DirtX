using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class TrailerSeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerType",
                table: "Trailers");

            migrationBuilder.RenameColumn(
                name: "TrailerId",
                table: "Trailers",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Trailers",
                columns: new[] { "Id", "Capacity", "CostPerDay", "ImageUrl", "IsAvailable", "MaximumLoad" },
                values: new object[] { 1, 1, 30m, "https://i.ibb.co/3zZVXNd/capacity-1.jpg", true, 200 });

            migrationBuilder.InsertData(
                table: "Trailers",
                columns: new[] { "Id", "Capacity", "CostPerDay", "ImageUrl", "IsAvailable", "MaximumLoad" },
                values: new object[] { 2, 2, 45m, "https://i.ibb.co/Fxnr737/capacity-2.jpg", true, 450 });

            migrationBuilder.InsertData(
                table: "Trailers",
                columns: new[] { "Id", "Capacity", "CostPerDay", "ImageUrl", "IsAvailable", "MaximumLoad" },
                values: new object[] { 3, 3, 60m, "https://i.ibb.co/TR8jdFq/capacity-3.jpg", true, 750 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trailers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trailers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trailers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trailers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trailers",
                newName: "TrailerId");

            migrationBuilder.AddColumn<string>(
                name: "TrailerType",
                table: "Trailers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
