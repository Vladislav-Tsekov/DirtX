using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class MinorNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "KYB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "KYB Suspension");
        }
    }
}
