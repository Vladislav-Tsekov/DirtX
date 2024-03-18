using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class InitialTablePerHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorcyclesParts_Parts_PartId",
                table: "MotorcyclesParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ProductBrands_BrandId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Gears_GearId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Oils_OilId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Parts_PartId",
                table: "ProductProperties");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "Oils");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_GearId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_OilId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_PartId",
                table: "ProductProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "GearId",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "OilId",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "ProductProperties");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_BrandId",
                table: "Product",
                newName: "IX_Product_BrandId");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Gear_Type",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Oil_Type",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PackageSize",
                table: "Product",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_set",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PropertyProductMapper",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyProductMapper", x => new { x.ProductsId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_PropertyProductMapper_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyProductMapper_ProductProperties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "ProductProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyProductMapper_PropertiesId",
                table: "PropertyProductMapper",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorcyclesParts_Product_PartId",
                table: "MotorcyclesParts",
                column: "PartId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductBrands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorcyclesParts_Product_PartId",
                table: "MotorcyclesParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductBrands_BrandId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "PropertyProductMapper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Gear_Type",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Oil_Type",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PackageSize",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "product_set",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Parts");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandId",
                table: "Parts",
                newName: "IX_Parts_BrandId");

            migrationBuilder.AddColumn<int>(
                name: "GearId",
                table: "ProductProperties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OilId",
                table: "ProductProperties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "ProductProperties",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gears_ProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    PackageSize = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oils_ProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_GearId",
                table: "ProductProperties",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_OilId",
                table: "ProductProperties",
                column: "OilId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_PartId",
                table: "ProductProperties",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Gears_BrandId",
                table: "Gears",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Oils_BrandId",
                table: "Oils",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorcyclesParts_Parts_PartId",
                table: "MotorcyclesParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ProductBrands_BrandId",
                table: "Parts",
                column: "BrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Gears_GearId",
                table: "ProductProperties",
                column: "GearId",
                principalTable: "Gears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Oils_OilId",
                table: "ProductProperties",
                column: "OilId",
                principalTable: "Oils",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Parts_PartId",
                table: "ProductProperties",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");
        }
    }
}
