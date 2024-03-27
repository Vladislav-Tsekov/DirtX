using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class DbOverhaul1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsProducts_Product_ProductId",
                table: "CartsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorcyclesParts_Product_PartId",
                table: "MotorcyclesParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductBrands_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecification_Product_ProductsId",
                table: "ProductSpecification");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSpecifications_Product_ProductId",
                table: "ProductsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Product_ProductId",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GearSize",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GearType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OilType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PackageSize",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PartType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductSet",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "MotorcyclesParts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MotorcyclesParts_PartId",
                table: "MotorcyclesParts",
                newName: "IX_MotorcyclesParts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.ibb.co/jTnS3W0/Product-High-Comp-Piston.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://i.ibb.co/m6fQKSx/Product-Forged-Piston.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/1RXqkVy/Product-Engine-Cover.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.ibb.co/Yj4MJ6r/Product-Top-End-Gasket.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.ibb.co/ZHQ36hf/Product-Water-Pump-Cover.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.ibb.co/dmkcV30/Product-Fuel-Injector.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i.ibb.co/fG9XLdn/Product-Intake-Valves.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://i.ibb.co/LnW1Y4k/Product-Fuel-Pump.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/vqg672F/Product-Air-Filter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Title", "Type" },
                values: new object[] { "https://i.ibb.co/kG1KnVN/Product-Product-Filter.jpg", "Product Filter", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageUrl", "Title", "Type" },
                values: new object[] { "https://i.ibb.co/V2qj6c0/Product-Product-Filter-Cap.jpg", "Aluminum Product Filter Cap", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/s1YdYwt/Product-Fuel-Filter-Tank.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/tc2m4jh/Product-Brake-Pads.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/1RqcRGm/Product-Brake-Lever.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/DG6HpM4/Product-Front-Brake-Disc.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/BNPMF26/Product-Rear-Brake-Disc.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/LRQphRW/Product-Shock-Absorber.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/yyZK9tT/Product-Fork-Springs.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/7jy1dvG/Product-Fork-Seals.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/LtFwYZ3/Product-KYB-Shock.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/VCWrYtY/Product-Steering-Bearings.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/9tCHFWY/Product-Chain.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/9tCHFWY/Product-Chain.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/xGz2dVn/Product-Rear-Sprocket.png", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/9pKtqn6/Product-Front-Sprocket.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/y0KwgV5/Product-Clutch-Kit.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/9qGztRG/Product-Clutch-Plates.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/Cm7S8dG/Product-Cross-Power-2-T.jpg", 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/9Nyc55B/Product-Motul-300-V-1-L.jpg", 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/3ywBxpQ/Product-Motul-300-V-4-L.jpg", 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ImageUrl", "Title", "Type" },
                values: new object[] { "https://i.ibb.co/W52svBD/Product-Bel-Ray-Fork-5-W.jpg", "Fork Product 5W", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "ImageUrl", "Title", "Type" },
                values: new object[] { "Performance Line Products Series is used by MXGP Factory teams.", "https://i.ibb.co/f1fW4j5/Product-Motorex-Shock-Product.jpg", "Performance Line: Shock Product", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/2dRRzHy/Product-Yamalube-10w40.jpg", 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/9rgYKcv/Product-Motul-Antifreeze.jpg", 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ImageUrl", "Title", "Type" },
                values: new object[] { "https://i.ibb.co/zntBCFg/Product-Transmission-Motul.jpg", "TransProduct Expert 10W40", 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/rs2c1Pd/Product-SM5-Helmet.jpg", 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/YkHnz4F/Product-3-Series-Oneal.jpg", 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/RhPrZB3/Product-Bionic-Action.jpg", 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/JrJSf2y/Product-Asterix-Knee.jpg", 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/bRsz5gz/Product-Jersey-50th.jpg", 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/hcZKcsB/Product-Thor-Outfit.jpg", 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/pzGDVTv/Product-Tech10-Boots.jpg", 13 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/34RRszr/Product-Blitz-Thor.jpg", 13 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/sHzPG34/Product-B20-Goggles.jpg", 14 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ImageUrl", "Type" },
                values: new object[] { "https://i.ibb.co/4Rf2r40/Product-Element-Gloves.jpg", 14 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartsProducts_Products_ProductId",
                table: "CartsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorcyclesParts_Products_ProductId",
                table: "MotorcyclesParts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategory_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecification_Products_ProductsId",
                table: "ProductSpecification",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSpecifications_Products_ProductId",
                table: "ProductsSpecifications",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Products_ProductId",
                table: "Wishlists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsProducts_Products_ProductId",
                table: "CartsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorcyclesParts_Products_ProductId",
                table: "MotorcyclesParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategory_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecification_Products_ProductsId",
                table: "ProductSpecification");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSpecifications_Products_ProductId",
                table: "ProductsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Products_ProductId",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "MotorcyclesParts",
                newName: "PartId");

            migrationBuilder.RenameIndex(
                name: "IX_MotorcyclesParts_ProductId",
                table: "MotorcyclesParts",
                newName: "IX_MotorcyclesParts_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Product",
                newName: "IX_Product_BrandId");

            migrationBuilder.AddColumn<int>(
                name: "GearSize",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GearType",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OilType",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PackageSize",
                table: "Product",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartType",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductSet",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Description", "GearSize", "GearType", "ImageUrl", "IsAvailable", "Price", "ProductSet", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 36, 1, "Alpinestars' premium class lightweight motorcycle helmet for maximum protection.", 1, 0, "https://i.ibb.co/rs2c1Pd/Gear-SM5-Helmet.jpg", true, 899.99m, "Gear", 2, "SM5" },
                    { 37, 13, "High-quality full-face racing helmet with aerodynamic design.", 0, 0, "https://i.ibb.co/YkHnz4F/Gear-3-Series-Oneal.jpg", true, 279.99m, "Gear", 7, "3-Series" },
                    { 38, 1, "Durable protective vest for safe riding.", 2, 1, "https://i.ibb.co/RhPrZB3/Gear-Bionic-Action.jpg", true, 319.99m, "Gear", 4, "Bionic Action V2" },
                    { 39, 15, "Knee protection that allows for some movement while protecting the knee cap and shin.", 1, 1, "https://i.ibb.co/JrJSf2y/Gear-Asterix-Knee.jpg", true, 179.99m, "Gear", 10, "AsteriX Knee Braces" },
                    { 40, 13, "Limited anniversary edition jersey.", 2, 2, "https://i.ibb.co/bRsz5gz/Gear-Jersey-50th.jpg", true, 79.99m, "Gear", 3, "50th Anniversary Jersey" },
                    { 41, 15, "A complete outfit of THOR's middle-class 'Prime Ace' line.", 1, 2, "https://i.ibb.co/hcZKcsB/Gear-Thor-Outfit.jpg", true, 259.99m, "Gear", 5, "Prime Ace Complete Outfit" },
                    { 42, 1, "The most advanced riding boots on the market.", 1, 3, "https://i.ibb.co/pzGDVTv/Gear-Tech10-Boots.jpg", true, 1099.99m, "Gear", 2, "Tech10" },
                    { 43, 13, "Motocross/Enduro boots with waterproof lining and reinforced toe.", 2, 3, "https://i.ibb.co/34RRszr/Gear-Blitz-Thor.jpg", true, 559.99m, "Gear", 6, "Blitz XR" },
                    { 44, 13, "Motocross goggles with flippers.", 1, 4, "https://i.ibb.co/sHzPG34/Gear-B20-Goggles.jpg", true, 129.99m, "Gear", 6, "B20 Goggles" },
                    { 45, 13, "Universal offroad gloves.", 3, 4, "https://i.ibb.co/4Rf2r40/Gear-Element-Gloves.jpg", true, 39.99m, "Gear", 11, "Element Gloves" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "IsAvailable", "OilType", "PackageSize", "Price", "ProductSet", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 28, 9, "Premium 2-stroke oil for motorcycle engines.", "https://i.ibb.co/Cm7S8dG/Oil-Cross-Power-2-T.jpg", true, 0, 1.0, 28.99m, "Oil", 30, "2T Cross Power" },
                    { 29, 10, "Ester Core Premium 4-stroke oil for motorcycle engines.", "https://i.ibb.co/9Nyc55B/Oil-Motul-300-V-1-L.jpg", true, 1, 1.0, 34.99m, "Oil", 12, "300V 15W60 1L" },
                    { 30, 10, "Ester Core Premium 4-stroke oil for motorcycle engines.", "https://i.ibb.co/3ywBxpQ/Oil-Motul-300-V-4-L.jpg", true, 1, 4.0, 114.99m, "Oil", 3, "300V 10W40 4L" },
                    { 31, 2, "Lightweight fork oil for smoother suspension stroke.", "https://i.ibb.co/W52svBD/Oil-Bel-Ray-Fork-5-W.jpg", true, 3, 0.5, 27.00m, "Oil", 8, "Fork Oil 5W" },
                    { 32, 9, "Performance Line Oils Series is used by MXGP Factory teams.", "https://i.ibb.co/f1fW4j5/Oil-Motorex-Shock-Oil.jpg", true, 3, 0.75, 29.99m, "Oil", 8, "Performance Line: Shock Oil" },
                    { 33, 19, "The baseline 4-stroke engine oil for motorcycles.", "https://i.ibb.co/2dRRzHy/Oil-Yamalube-10w40.jpg", true, 1, 1.5, 26.29m, "Oil", 14, "YAMALUBE 10W40" },
                    { 34, 10, "The most efficient coolant on the market.", "https://i.ibb.co/9rgYKcv/Oil-Motul-Antifreeze.jpg", true, 4, 1.0, 26.29m, "Oil", 14, "AutoCool -35°C 1L" },
                    { 35, 10, "More throttle, less grinding gears.", "https://i.ibb.co/zntBCFg/Oil-Transmission-Motul.jpg", true, 2, 1.0, 28.29m, "Oil", 4, "TransOil Expert 10W40" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "IsAvailable", "PartType", "Price", "ProductSet", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 1, 17, "High-quality forged piston for 4-Stroke motorcycle engines. Rings and pin are included in the set.", "https://i.ibb.co/jTnS3W0/Part-High-Comp-Piston.jpg", true, 0, 455.00m, "Part", 11, "High-Compression Forged Piston" },
                    { 2, 18, "High-performance cast piston. Piston rings are not included.", "https://i.ibb.co/m6fQKSx/Part-Forged-Piston.jpg", true, 0, 325.00m, "Part", 6, "Cast Piston" },
                    { 3, 7, "Protective cover for motorcycle engines made of titanium.", "https://i.ibb.co/1RXqkVy/Part-Engine-Cover.png", true, 0, 99.99m, "Part", 4, "Engine Clutch Cover" },
                    { 4, 3, "Complete gasket set for top-end engine rebuilds and maintenance.", "https://i.ibb.co/Yj4MJ6r/Part-Top-End-Gasket.jpg", true, 0, 89.99m, "Part", 31, "Top-End Gasket Set" },
                    { 5, 3, "Enhanced water pump cover for improved cooling efficiency.", "https://i.ibb.co/ZHQ36hf/Part-Water-Pump-Cover.jpg", true, 0, 87.79m, "Part", 10, "Water Pump Cover" },
                    { 6, 12, "High-flow fuel injector for increased horsepower, throttle response and fuel efficiency.", "https://i.ibb.co/dmkcV30/Part-Fuel-Injector.jpg", true, 0, 289.99m, "Part", 3, "8-Point Fuel Injector" },
                    { 7, 17, "A set of two high-quality intake valves that exceed OEM quality.", "https://i.ibb.co/fG9XLdn/Part-Intake-Valves.jpg", true, 0, 139.29m, "Part", 7, "Intake Valves Set" },
                    { 8, 18, "Electric fuel pump for replacing the old one. Comes with all necessary components.", "https://i.ibb.co/LnW1Y4k/Part-Fuel-Pump.jpg", true, 0, 149.99m, "Part", 12, "Fuel Pump" },
                    { 9, 16, "Premium air filter for improved air flow and engine performance.", "https://i.ibb.co/vqg672F/Part-Air-Filter.jpg", true, 1, 24.49m, "Part", 27, "Air Filter" },
                    { 10, 6, "High-quality oil filter for efficient filtration and engine longevity.", "https://i.ibb.co/kG1KnVN/Part-Oil-Filter.jpg", true, 1, 10.99m, "Part", 19, "Oil Filter" },
                    { 11, 16, "High-quality oil filter for efficient filtration and engine longevity.", "https://i.ibb.co/V2qj6c0/Part-Oil-Filter-Cap.jpg", true, 1, 54.29m, "Part", 8, "Aluminum Oil Filter Cap" },
                    { 12, 16, "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal.", "https://i.ibb.co/s1YdYwt/Part-Fuel-Filter-Tank.jpg", true, 1, 50.99m, "Part", 5, "Fuel Filter (Gas Tank)" },
                    { 13, 5, "Replacement brake pads offering reliable stopping performance.", "https://i.ibb.co/tc2m4jh/Part-Brake-Pads.jpg", true, 3, 35.89m, "Part", 20, "Sintered Front Brake Pads" },
                    { 14, 11, "Comfortable and durable lever, made out of aluminum for improved control and comfort.", "https://i.ibb.co/1RqcRGm/Part-Brake-Lever.jpg", true, 3, 71.99m, "Part", 14, "Aluminum Brake Lever" },
                    { 15, 11, "High-performance brake disc for superior stopping power.", "https://i.ibb.co/DG6HpM4/Part-Front-Brake-Disc.jpg", true, 3, 89.99m, "Part", 1, "Front Brake Disc" },
                    { 16, 11, "High-performance brake disc for superior stopping power.", "https://i.ibb.co/BNPMF26/Part-Rear-Brake-Disc.jpg", true, 3, 77.29m, "Part", 7, "Rear Brake Disc" },
                    { 17, 14, "Precision-engineered shock absorber for smooth ride experience.", "https://i.ibb.co/LRQphRW/Part-Shock-Absorber.jpg", true, 4, 799.19m, "Part", 3, "Shock Absorber" },
                    { 18, 14, "Upgraded front fork springs for improved suspension response and handling. Set of two.", "https://i.ibb.co/yyZK9tT/Part-Fork-Springs.jpg", true, 4, 429.99m, "Part", 5, "Front Fork Springs" },
                    { 19, 8, "Seal kit for motorcycle forks to prevent leaks and maintain suspension performance.", "https://i.ibb.co/7jy1dvG/Part-Fork-Seals.jpg", true, 4, 44.99m, "Part", 18, "Fork Seal Kit" },
                    { 20, 8, "The latest KYB technology is used to develop this shock, used by Yamaha Factory Racing drivers.", "https://i.ibb.co/LtFwYZ3/Part-KYB-Shock.jpg", true, 4, 1404.49m, "Part", 2, "HI-C Shock Absorber" },
                    { 21, 14, "Designed as a drop-in replacement to upgrade OEM ball-type bearings to taper bearings.", "https://i.ibb.co/VCWrYtY/Part-Steering-Bearings.jpg", true, 4, 125.50m, "Part", 6, "Steering Stem Bearing Kit" },
                    { 22, 4, "Durable motorcycle chain for smooth power transfer.", "https://i.ibb.co/9tCHFWY/Part-Chain.jpg", true, 2, 119.99m, "Part", 10, "114-Links Chain" },
                    { 23, 4, "Durable motorcycle chain for smooth power transfer.", "https://i.ibb.co/9tCHFWY/Part-Chain.jpg", true, 2, 129.99m, "Part", 7, "120-Links Chain" },
                    { 24, 4, "Quality rear sprocked made out of aluminum.", "https://i.ibb.co/xGz2dVn/Part-Rear-Sprocket.png", true, 2, 89.79m, "Part", 4, "52-Teeth Rear Sprocket" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "IsAvailable", "PartType", "Price", "ProductSet", "StockQuantity", "Title" },
                values: new object[] { 25, 4, "Standart-sized front sprocked with self-cleaning properties.", "https://i.ibb.co/9pKtqn6/Part-Front-Sprocket.jpg", true, 2, 24.19m, "Part", 13, "13-Teeth Front Sprocket" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "IsAvailable", "PartType", "Price", "ProductSet", "StockQuantity", "Title" },
                values: new object[] { 26, 7, "Complete clutch kit for enhanced performance and durability.", "https://i.ibb.co/y0KwgV5/Part-Clutch-Kit.jpg", true, 2, 2149.99m, "Part", 3, "Complete Clutch Kit" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "IsAvailable", "PartType", "Price", "ProductSet", "StockQuantity", "Title" },
                values: new object[] { 27, 17, "Clutch plate kit with friction plates and steel plates for smooth engagement.", "https://i.ibb.co/9qGztRG/Part-Clutch-Plates.jpg", true, 2, 339.69m, "Part", 8, "Clutch Plate Kit" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartsProducts_Product_ProductId",
                table: "CartsProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecification_Product_ProductsId",
                table: "ProductSpecification",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSpecifications_Product_ProductId",
                table: "ProductsSpecifications",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Product_ProductId",
                table: "Wishlists",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
