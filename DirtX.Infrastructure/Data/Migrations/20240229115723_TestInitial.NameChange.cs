using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class TestInitialNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsProperties_Parts_PartId",
                table: "ProductsProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsProperties",
                table: "ProductsProperties");

            migrationBuilder.RenameTable(
                name: "ProductsProperties",
                newName: "ProductProperties");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsProperties_PartId",
                table: "ProductProperties",
                newName: "IX_ProductProperties_PartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProperties",
                table: "ProductProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Parts_PartId",
                table: "ProductProperties",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Parts_PartId",
                table: "ProductProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProperties",
                table: "ProductProperties");

            migrationBuilder.RenameTable(
                name: "ProductProperties",
                newName: "ProductsProperties");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProperties_PartId",
                table: "ProductsProperties",
                newName: "IX_ProductsProperties_PartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsProperties",
                table: "ProductsProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsProperties_Parts_PartId",
                table: "ProductsProperties",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
