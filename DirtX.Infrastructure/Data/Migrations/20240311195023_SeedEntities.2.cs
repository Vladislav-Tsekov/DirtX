using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class SeedEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Oils",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "IsAvailable", "PackageSize", "Price", "StockQuantity", "Title", "Type" },
                values: new object[] { 8, 2, "More throttle, less grinding gears.", "https://i.ibb.co/zntBCFg/Oil-Transmission-Motul.jpg", true, 1.0, 28.29m, 4, "TransOil Expert 10W40", 2 });

            migrationBuilder.InsertData(
                table: "OilsProperties",
                columns: new[] { "OilId", "SpecificationId" },
                values: new object[] { 8, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
