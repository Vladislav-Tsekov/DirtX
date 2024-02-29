using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class PropertiesMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "RidingGears");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gears_ProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearSpecifications_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GearSpecifications_SpecificationTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SpecificationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OilId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilSpecifications_Oils_OilId",
                        column: x => x.OilId,
                        principalTable: "Oils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OilSpecifications_SpecificationTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SpecificationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartSpecifications_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartSpecifications_SpecificationTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SpecificationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearsProperties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    GearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearsProperties", x => new { x.GearId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_GearsProperties_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GearsProperties_GearSpecifications_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "GearSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilsProperties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    OilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilsProperties", x => new { x.OilId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_OilsProperties_Oils_OilId",
                        column: x => x.OilId,
                        principalTable: "Oils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OilsProperties_OilSpecifications_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "OilSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartsProperties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsProperties", x => new { x.PartId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_PartsProperties_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsProperties_PartSpecifications_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PartSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MotoDisplacements",
                columns: new[] { "Id", "Displacement" },
                values: new object[,]
                {
                    { 1, 250 },
                    { 2, 300 },
                    { 3, 350 },
                    { 4, 450 }
                });

            migrationBuilder.InsertData(
                table: "MotoMakes",
                columns: new[] { "Id", "Make" },
                values: new object[,]
                {
                    { 1, "Yamaha" },
                    { 2, "Honda" },
                    { 3, "Suzuki" },
                    { 4, "Kawasaki" },
                    { 5, "KTM" },
                    { 6, "Husqvarna" },
                    { 7, "GASGAS" }
                });

            migrationBuilder.InsertData(
                table: "MotoModels",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { 1, "YZ-F" },
                    { 2, "CRF" },
                    { 3, "RM-Z" },
                    { 4, "KX-F" },
                    { 5, "SX-F" },
                    { 6, "FC" },
                    { 7, "MC-F" }
                });

            migrationBuilder.InsertData(
                table: "MotoYears",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { 1, 2005 },
                    { 2, 2006 },
                    { 3, 2007 },
                    { 4, 2008 },
                    { 5, 2009 },
                    { 6, 2010 },
                    { 7, 2011 },
                    { 8, 2012 },
                    { 9, 2013 },
                    { 10, 2014 },
                    { 11, 2015 },
                    { 12, 2016 },
                    { 13, 2017 },
                    { 14, 2018 },
                    { 15, 2019 },
                    { 16, 2020 },
                    { 17, 2021 },
                    { 18, 2022 },
                    { 19, 2023 },
                    { 20, 2024 },
                    { 21, 2025 },
                    { 22, 2026 },
                    { 23, 2027 },
                    { 24, 2028 }
                });

            migrationBuilder.InsertData(
                table: "MotoYears",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { 25, 2029 },
                    { 26, 2030 }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Alpinestars is an Italian motorsports and action sports safety equipment manufacturer based in Asolo, Italy.", "Alpinestars" },
                    { 2, "A leader in lubrication technology, Bel-Ray has engineered products to protect, while delivering superior business value for application in automotive, motorcycle, powersports, steel, textile and other industries.", "BEL-RAY" },
                    { 3, "Boyesen has captured the attention of Racing teams, leveraging their engineering and manufacturing mastery to create water pump covers and impellers, ignition and clutch covers.", "Boyesen" },
                    { 4, "At D.I.D, our passion for motorcycles and commitment to excellence drives us to deliver the finest motorcycle chains in the industry.", "D.I.D" },
                    { 5, "Description for Brand C", "Galfer" },
                    { 6, "Galfer USA is the leading manufacturer of performance braking systems and accessories for motorcycle enthusiasts and racers alike.", "HifloFiltro" },
                    { 7, "Hinson clutch components is the choice of most major factory teams and riders and has proven itself to be the best quality for many years.", "Hinson" },
                    { 8, "All KYB shock absorbers are designed to the highest standards and are manufactured in the same facilities that build shocks for new vehicle manufacturers.", "KYB Suspension" },
                    { 9, "Motorex is a Swiss family-owned company specializing in the development, production and marketing of lubricants, metalworking fluids, technical cleaning and care products.", "Motorex" },
                    { 10, "Founded in 1853, Motul is a French company with an international footprint specialized in the formulation, production, and distribution of high-performance lubricants for engines.", "MOTUL" },
                    { 11, "At Moto-Master we are passionate about motorcycles and it is our mission to improve the riding experience of our customers by providing them with the best brake setup possible.", "Moto-Master" },
                    { 12, "With over 80 years of automotive expertise, we are driven by extreme dedication to performance and quality. Our people push the boundaries of innovation to bring the latest technologies to market.", "NGK" },
                    { 13, "O’NEAL (est. 1970) is a global leader in protective apparel and accessories.  For more than half a century O’NEAL has been designing and developing helmets, jerseys, pants, protectors, gloves, boots and much more.", "O'NEAL" },
                    { 14, "Showa is a brand of high-performance automotive, motorcycle and outboard suspension systems of Hitachi Astemo, based in Gyoda, Saitama in Japan.", "Showa" },
                    { 15, "Check out our latest Motocross outfits, backed by the top riders in the sport.", "THOR" },
                    { 16, "Twin Air produces air filters and oil filters as well as performance upgrades for all types of motorcycles, ATVs, Karts and RC products.", "Twin Air" },
                    { 17, "Vertex is considered the premier brand of OEM replacement pistons and is the OEM supplier to KTM and numerous European motorcycle and go-kart manufacturers.", "Vertex" },
                    { 18, "Wiseco was born 80 years ago from a passion for the performance and racing lifestyle and evolved from garage-made pistons to an industry leader in aftermarket performance.", "Wiseco" },
                    { 19, "YAMALUBE is an engine oil developed in-house by Yamaha specifically for motorcycles.", "YAMALUBE" }
                });

            migrationBuilder.InsertData(
                table: "Gears",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "Price", "Size", "StockQuantity", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 6, "Premium motorcycle helmet for maximum protection.", true, 99.99m, 1, 5, "Helmet", 0 },
                    { 2, 7, "Durable protective jacket for safe riding.", true, 149.99m, 2, 7, "Protective Jacket", 1 }
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "DisplacementId", "MakeId", "ModelId", "YearId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 5 },
                    { 2, 4, 2, 2, 15 },
                    { 3, 1, 3, 3, 10 },
                    { 4, 1, 4, 4, 11 },
                    { 5, 3, 5, 5, 17 },
                    { 6, 4, 6, 6, 13 },
                    { 7, 1, 7, 7, 18 }
                });

            migrationBuilder.InsertData(
                table: "Oils",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "PackageSize", "Price", "StockQuantity", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 9, "Premium 2-stroke oil for motorcycle engines.", true, 1.0, 28.99m, 30, "2T Cross Power", 0 },
                    { 2, 10, "Ester Core Premium 4-stroke oil for motorcycle engines.", true, 1.0, 34.99m, 12, "300V 15W60 1L", 1 },
                    { 3, 10, "Ester Core Premium 4-stroke oil for motorcycle engines.", true, 4.0, 114.99m, 3, "300V 10W40 4L", 1 },
                    { 4, 2, "Lightweight fork oil for smoother suspension stroke.", true, 0.5, 27.00m, 8, "Fork Oil 5W", 3 },
                    { 5, 9, "Performance Line Oils Series is used by MXGP Factory teams.", true, 0.75, 29.99m, 8, "Performance Line: Shock Oil", 3 },
                    { 6, 19, "The baseline 4-stroke engine oil for motorcycles.", true, 1.5, 26.29m, 14, "YAMALUBE 10W40", 1 },
                    { 7, 10, "The baseline 4-stroke engine oil for motorcycles.", true, 1.0, 26.29m, 14, "MotoCool -35°C 1L", 4 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "Price", "StockQuantity", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 17, "High-quality forged piston for 4-Stroke motorcycle engines. Rings and pin are included in the set.", true, 455.00m, 11, "High-Compression Forged Piston", 0 },
                    { 2, 18, "High-performance cast piston. Piston rings are not included.", true, 325.00m, 6, "Cast Piston", 0 },
                    { 3, 7, "Protective cover for motorcycle engines made of titanium.", true, 99.99m, 4, "Engine Clutch Cover", 0 },
                    { 4, 3, "Complete gasket set for top-end engine rebuilds and maintenance.", true, 89.99m, 31, "Top-End Gasket Set", 0 },
                    { 5, 3, "Enhanced water pump cover for improved cooling efficiency.", true, 87.79m, 10, "Water Pump Cover", 0 },
                    { 6, 12, "High-flow fuel injector for increased horsepower, throttle response and fuel efficiency.", true, 289.99m, 3, "8-Point Fuel Injector", 0 },
                    { 7, 17, "A set of two high-quality intake valves that exceed OEM quality.", true, 139.29m, 7, "Intake Valves Set", 0 },
                    { 8, 18, "Electric fuel pump for replacing the old one. Comes with all necessary components.", true, 149.99m, 12, "Fuel Pump", 0 },
                    { 9, 16, "Premium air filter for improved air flow and engine performance.", true, 24.49m, 27, "Air Filter", 1 },
                    { 10, 6, "High-quality oil filter for efficient filtration and engine longevity.", true, 10.99m, 19, "Oil Filter", 1 },
                    { 11, 16, "High-quality oil filter for efficient filtration and engine longevity.", true, 54.29m, 8, "Aluminium Oil Filter Cap", 1 },
                    { 12, 16, "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal", true, 50.99m, 5, "Fuel Filter (Gas Tank)", 1 },
                    { 13, 5, "Replacement brake pads offering reliable stopping performance.", true, 35.89m, 20, "Sintered Front Brake Pads", 3 },
                    { 14, 11, "Comfortable and durable lever, made out of aluminium for improved control and comfort.", true, 71.99m, 14, "Aluminium Brake Lever", 3 },
                    { 15, 11, "High-performance brake disc for superior stopping power.", true, 89.99m, 1, "Front Brake Disc", 3 },
                    { 16, 11, "High-performance brake disc for superior stopping power.", true, 77.29m, 7, "Rear Brake Disc", 3 },
                    { 17, 14, "Precision-engineered shock absorber for smooth ride experience.", true, 799.19m, 3, "Shock Absorber", 4 },
                    { 18, 14, "Upgraded front fork springs for improved suspension response and handling. Set of two.", true, 429.99m, 5, "Front Fork Springs", 4 },
                    { 19, 8, "Seal kit for motorcycle forks to prevent leaks and maintain suspension performance.", true, 44.99m, 18, "Fork Seal Kit", 4 },
                    { 20, 8, "The latest KYB technology is used to develop this shock, used by Yamaha Factory Racing drivers.", true, 1404.49m, 2, "HI-C Shock Absorber", 4 },
                    { 21, 14, "Designed as a drop-in replacement to upgrade OEM ball-type bearings to taper bearings.", true, 125.50m, 6, "Steering Stem Bearing Kit", 4 },
                    { 22, 4, "Durable motorcycle chain for smooth power transfer.", true, 119.99m, 10, "114-Links Chain", 2 },
                    { 23, 4, "Durable motorcycle chain for smooth power transfer.", true, 129.99m, 7, "120-Links Chain", 2 },
                    { 24, 4, "Durable motorcycle chain for smooth power transfer.", true, 89.79m, 4, "52-Teeth Rear Sprocket", 2 },
                    { 25, 4, "Durable motorcycle chain for smooth power transfer.", true, 24.19m, 13, "13-Teeth Front Sprocket", 2 },
                    { 26, 7, "Complete clutch kit for enhanced performance and durability.", true, 2149.99m, 3, "Complete Clutch Kit", 2 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "Price", "StockQuantity", "Title", "Type" },
                values: new object[] { 27, 17, "Complete clutch plate kit with friction plates and steel plates for smooth engagement.", true, 339.69m, 8, "Clutch Plate Kit", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Gears_BrandId",
                table: "Gears",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSpecifications_GearId",
                table: "GearSpecifications",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSpecifications_TitleId",
                table: "GearSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_GearsProperties_PropertyId",
                table: "GearsProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecifications_OilId",
                table: "OilSpecifications",
                column: "OilId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecifications_TitleId",
                table: "OilSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_OilsProperties_PropertyId",
                table: "OilsProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartSpecifications_PartId",
                table: "PartSpecifications",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartSpecifications_TitleId",
                table: "PartSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsProperties_PropertyId",
                table: "PartsProperties",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GearsProperties");

            migrationBuilder.DropTable(
                name: "OilsProperties");

            migrationBuilder.DropTable(
                name: "PartsProperties");

            migrationBuilder.DropTable(
                name: "GearSpecifications");

            migrationBuilder.DropTable(
                name: "OilSpecifications");

            migrationBuilder.DropTable(
                name: "PartSpecifications");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "SpecificationTitles");

            migrationBuilder.DeleteData(
                table: "MotoDisplacements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MotoDisplacements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotoDisplacements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotoDisplacements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MotoYears",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RidingGears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RidingGears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RidingGears_ProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_PartId",
                table: "ProductProperties",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_RidingGears_BrandId",
                table: "RidingGears",
                column: "BrandId");
        }
    }
}
