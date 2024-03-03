using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class SeedEntities1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotoDisplacements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Displacement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoDisplacements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotoMakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotoYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    DisplacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorcycles_MotoDisplacements_DisplacementId",
                        column: x => x.DisplacementId,
                        principalTable: "MotoDisplacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Motorcycles_MotoMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "MotoMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Motorcycles_MotoModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "MotoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Motorcycles_MotoYears_YearId",
                        column: x => x.YearId,
                        principalTable: "MotoYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Oils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PackageSize = table.Column<double>(type: "float", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oils_ProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_ProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GearSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearSpecifications_SpecificationTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SpecificationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OilSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilSpecifications_SpecificationTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SpecificationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PartSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartSpecifications_SpecificationTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SpecificationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MotorcyclesParts",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcyclesParts", x => new { x.MotorcycleId, x.PartId });
                    table.ForeignKey(
                        name: "FK_MotorcyclesParts_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MotorcyclesParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GearsProperties",
                columns: table => new
                {
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    GearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearsProperties", x => new { x.GearId, x.SpecificationId });
                    table.ForeignKey(
                        name: "FK_GearsProperties_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GearsProperties_GearSpecifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "GearSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OilsProperties",
                columns: table => new
                {
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    OilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilsProperties", x => new { x.OilId, x.SpecificationId });
                    table.ForeignKey(
                        name: "FK_OilsProperties_Oils_OilId",
                        column: x => x.OilId,
                        principalTable: "Oils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OilsProperties_OilSpecifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "OilSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PartsProperties",
                columns: table => new
                {
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsProperties", x => new { x.PartId, x.SpecificationId });
                    table.ForeignKey(
                        name: "FK_PartsProperties_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartsProperties_PartSpecifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "PartSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "MotoDisplacements",
                columns: new[] { "Id", "Displacement" },
                values: new object[,]
                {
                    { 1, 250 },
                    { 2, 350 },
                    { 3, 450 }
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
                    { 20, 2024 }
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
                    { 5, "Galfer USA is the leading manufacturer of performance braking systems and accessories for motorcycle enthusiasts and racers alike.", "Galfer" }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "HifloFiltro specializes in the production of all types of filters for the motorcycle with the goal of harnessing maximum racing performance.", "HifloFiltro" },
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
                table: "SpecificationTitles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Material" },
                    { 2, "Manufacture Method" },
                    { 3, "Color" },
                    { 4, "Diameter" },
                    { 5, "Spring Rate" },
                    { 6, "Seal Fitment" },
                    { 7, "Viscosity" }
                });

            migrationBuilder.InsertData(
                table: "GearSpecifications",
                columns: new[] { "Id", "TitleId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Polyester Mesh" },
                    { 2, 1, "Cotton" },
                    { 3, 1, "Denim" },
                    { 4, 3, "Red" },
                    { 5, 3, "Blue" },
                    { 6, 3, "Green" },
                    { 7, 3, "Orange" },
                    { 8, 3, "White" },
                    { 9, 3, "Dark Gray" },
                    { 10, 3, "Black" }
                });

            migrationBuilder.InsertData(
                table: "Gears",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "Price", "Size", "StockQuantity", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Alpinestars' premium class lightweight motorcycle helmet for maximum protection.", true, 899.99m, 1, 2, "SM5", 0 },
                    { 2, 13, "High-quality full-face racing helmet with aerodynamic design.", true, 279.99m, 0, 7, "3-Series", 0 },
                    { 3, 1, "Durable protective vest for safe riding.", true, 319.99m, 2, 4, "Bionic Action V2", 1 },
                    { 4, 15, "Knee protection that allows for some movement while protecting the knee cap and shin.", true, 179.99m, 1, 10, "AsteriX Knee Braces", 1 },
                    { 5, 13, "Limited anniversary edition jersey.", true, 79.99m, 2, 3, "50th Anniversary Jersey", 2 },
                    { 6, 15, "A complete outfit of THOR's middle-class 'Prime Ace' line.", true, 259.99m, 1, 5, "Prime Ace Complete Outfit", 2 },
                    { 7, 1, "The most advanced riding boots on the market.", true, 1099.99m, 1, 2, "Tech10", 3 },
                    { 8, 13, "Motocross/Enduro boots with waterproof lining and reinforced toe.", true, 559.99m, 2, 6, "Blitz XR", 3 },
                    { 9, 13, "Motocross goggles with flippers.", true, 129.99m, 1, 6, "B20 Goggles", 4 },
                    { 10, 13, "Universal offroad gloves.", true, 39.99m, 3, 11, "Element Gloves", 4 }
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "DisplacementId", "MakeId", "ModelId", "YearId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 1, 1, 2 },
                    { 3, 3, 1, 1, 3 },
                    { 4, 3, 2, 2, 4 },
                    { 5, 3, 2, 2, 5 },
                    { 6, 1, 2, 2, 6 },
                    { 7, 3, 3, 3, 7 },
                    { 8, 1, 3, 3, 8 },
                    { 9, 1, 3, 3, 9 },
                    { 10, 3, 4, 4, 10 },
                    { 11, 1, 4, 4, 11 },
                    { 12, 3, 4, 4, 12 },
                    { 13, 1, 5, 5, 13 },
                    { 14, 2, 5, 5, 14 },
                    { 15, 3, 5, 5, 15 },
                    { 16, 1, 6, 6, 16 },
                    { 17, 1, 6, 6, 17 },
                    { 18, 3, 6, 6, 18 },
                    { 19, 1, 7, 7, 19 },
                    { 20, 3, 7, 7, 20 }
                });

            migrationBuilder.InsertData(
                table: "OilSpecifications",
                columns: new[] { "Id", "TitleId", "Value" },
                values: new object[,]
                {
                    { 1, 7, "5W" },
                    { 2, 7, "10W40" }
                });

            migrationBuilder.InsertData(
                table: "OilSpecifications",
                columns: new[] { "Id", "TitleId", "Value" },
                values: new object[,]
                {
                    { 3, 7, "15W60" },
                    { 4, 3, "Red" },
                    { 5, 3, "Blue" },
                    { 6, 3, "Green" }
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
                table: "PartSpecifications",
                columns: new[] { "Id", "TitleId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Aluminum" },
                    { 2, 1, "Titanium" },
                    { 3, 1, "Foam" },
                    { 4, 1, "Ferodo" },
                    { 5, 1, "Impregnated Cork" },
                    { 6, 1, "Steel" },
                    { 7, 2, "Cast" },
                    { 8, 2, "Forged" },
                    { 9, 3, "Red" },
                    { 10, 3, "Blue" },
                    { 11, 3, "Green" },
                    { 12, 3, "Orange" },
                    { 13, 3, "White" },
                    { 14, 3, "Dark Gray" },
                    { 15, 3, "Black" },
                    { 16, 4, "74.96mm" },
                    { 17, 4, "74.98mm" },
                    { 18, 4, "75.00mm" },
                    { 19, 4, "88.96mm" },
                    { 20, 4, "88.98mm" },
                    { 21, 4, "89.00mm" },
                    { 22, 5, "4.2kg/mm" },
                    { 23, 5, "4.6kg/mm" },
                    { 24, 5, "5.0kg/mm" },
                    { 25, 4, "220mm" },
                    { 26, 4, "270mm" },
                    { 27, 6, "48mm" },
                    { 28, 6, "50mm" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "Price", "StockQuantity", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 17, "High-quality forged piston for 4-Stroke motorcycle engines. Rings and pin are included in the set.", true, 455.00m, 11, "High-Compression Forged Piston", 0 },
                    { 2, 18, "High-performance cast piston. Piston rings are not included.", true, 325.00m, 6, "Cast Piston", 0 },
                    { 3, 7, "Protective cover for motorcycle engines made of titanium.", true, 99.99m, 4, "Engine Clutch Cover", 0 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "BrandId", "Description", "IsAvailable", "Price", "StockQuantity", "Title", "Type" },
                values: new object[,]
                {
                    { 4, 3, "Complete gasket set for top-end engine rebuilds and maintenance.", true, 89.99m, 31, "Top-End Gasket Set", 0 },
                    { 5, 3, "Enhanced water pump cover for improved cooling efficiency.", true, 87.79m, 10, "Water Pump Cover", 0 },
                    { 6, 12, "High-flow fuel injector for increased horsepower, throttle response and fuel efficiency.", true, 289.99m, 3, "8-Point Fuel Injector", 0 },
                    { 7, 17, "A set of two high-quality intake valves that exceed OEM quality.", true, 139.29m, 7, "Intake Valves Set", 0 },
                    { 8, 18, "Electric fuel pump for replacing the old one. Comes with all necessary components.", true, 149.99m, 12, "Fuel Pump", 0 },
                    { 9, 16, "Premium air filter for improved air flow and engine performance.", true, 24.49m, 27, "Air Filter", 1 },
                    { 10, 6, "High-quality oil filter for efficient filtration and engine longevity.", true, 10.99m, 19, "Oil Filter", 1 },
                    { 11, 16, "High-quality oil filter for efficient filtration and engine longevity.", true, 54.29m, 8, "Aluminum Oil Filter Cap", 1 },
                    { 12, 16, "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal", true, 50.99m, 5, "Fuel Filter (Gas Tank)", 1 },
                    { 13, 5, "Replacement brake pads offering reliable stopping performance.", true, 35.89m, 20, "Sintered Front Brake Pads", 3 },
                    { 14, 11, "Comfortable and durable lever, made out of aluminum for improved control and comfort.", true, 71.99m, 14, "Aluminum Brake Lever", 3 },
                    { 15, 11, "High-performance brake disc for superior stopping power.", true, 89.99m, 1, "Front Brake Disc", 3 },
                    { 16, 11, "High-performance brake disc for superior stopping power.", true, 77.29m, 7, "Rear Brake Disc", 3 },
                    { 17, 14, "Precision-engineered shock absorber for smooth ride experience.", true, 799.19m, 3, "Shock Absorber", 4 },
                    { 18, 14, "Upgraded front fork springs for improved suspension response and handling. Set of two.", true, 429.99m, 5, "Front Fork Springs", 4 },
                    { 19, 8, "Seal kit for motorcycle forks to prevent leaks and maintain suspension performance.", true, 44.99m, 18, "Fork Seal Kit", 4 },
                    { 20, 8, "The latest KYB technology is used to develop this shock, used by Yamaha Factory Racing drivers.", true, 1404.49m, 2, "HI-C Shock Absorber", 4 },
                    { 21, 14, "Designed as a drop-in replacement to upgrade OEM ball-type bearings to taper bearings.", true, 125.50m, 6, "Steering Stem Bearing Kit", 4 },
                    { 22, 4, "Durable motorcycle chain for smooth power transfer.", true, 119.99m, 10, "114-Links Chain", 2 },
                    { 23, 4, "Durable motorcycle chain for smooth power transfer.", true, 129.99m, 7, "120-Links Chain", 2 },
                    { 24, 4, "Quality rear sprocked made out of aluminum.", true, 89.79m, 4, "52-Teeth Rear Sprocket", 2 },
                    { 25, 4, "Standart-sized front sprocked with self-cleaning properties.", true, 24.19m, 13, "13-Teeth Front Sprocket", 2 },
                    { 26, 7, "Complete clutch kit for enhanced performance and durability.", true, 2149.99m, 3, "Complete Clutch Kit", 2 },
                    { 27, 17, "Clutch plate kit with friction plates and steel plates for smooth engagement.", true, 339.69m, 8, "Clutch Plate Kit", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gears_BrandId",
                table: "Gears",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSpecifications_TitleId",
                table: "GearSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_GearsProperties_SpecificationId",
                table: "GearsProperties",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_DisplacementId",
                table: "Motorcycles",
                column: "DisplacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MakeId_ModelId_YearId_DisplacementId",
                table: "Motorcycles",
                columns: new[] { "MakeId", "ModelId", "YearId", "DisplacementId" });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_ModelId",
                table: "Motorcycles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_YearId",
                table: "Motorcycles",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclesParts_PartId",
                table: "MotorcyclesParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Oils_BrandId",
                table: "Oils",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecifications_TitleId",
                table: "OilSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_OilsProperties_SpecificationId",
                table: "OilsProperties",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_BrandId",
                table: "Parts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PartSpecifications_TitleId",
                table: "PartSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsProperties_SpecificationId",
                table: "PartsProperties",
                column: "SpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GearsProperties");

            migrationBuilder.DropTable(
                name: "MotorcyclesParts");

            migrationBuilder.DropTable(
                name: "OilsProperties");

            migrationBuilder.DropTable(
                name: "PartsProperties");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "GearSpecifications");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Oils");

            migrationBuilder.DropTable(
                name: "OilSpecifications");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "PartSpecifications");

            migrationBuilder.DropTable(
                name: "MotoDisplacements");

            migrationBuilder.DropTable(
                name: "MotoMakes");

            migrationBuilder.DropTable(
                name: "MotoModels");

            migrationBuilder.DropTable(
                name: "MotoYears");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "SpecificationTitles");
        }
    }
}
