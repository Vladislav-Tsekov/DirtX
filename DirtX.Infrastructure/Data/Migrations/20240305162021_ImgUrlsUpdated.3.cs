using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class ImgUrlsUpdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/d6VvnbP/Brand-Boyesen.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/J7JkP6Q/Brand-Boyesen.png");
        }
    }
}
