using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Scraper.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketPrices",
                columns: table => new
                {
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    MotoCount = table.Column<int>(type: "int", nullable: false, comment: "The number of motorcycle announcements for the current make/year combination"),
                    AvgPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Average Price for each make/year combination"),
                    MeanTrimPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Mean Price for each make/year combination, calculated with a trim factor of 0.20"),
                    StdDevPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Standard Deviation Price for each make/year combination"),
                    MedianPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Median Price for each make/year combination"),
                    ModePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Mode Price (most frequent value, if such exists) for each make/year combination"),
                    PriceRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Price Range (most expensive - cheapest announcement) for each make/year combination"),
                    PriceVariance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The Price Variance coefficient for each make/year combination")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPrices", x => new { x.MakeId, x.YearId });
                    table.ForeignKey(
                        name: "FK_MarketPrices_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketPrices_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Link = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Each announcement link is unique, therefore used as a key"),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Displacement = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle's engine displacement in cubic centimeters"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Motorcycle's actual price"),
                    PriceChanges = table.Column<int>(type: "int", nullable: false, comment: "Announcement's number of price changes"),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price's value before it was changed"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of announcement's addition to the database"),
                    IsSold = table.Column<bool>(type: "bit", nullable: false, comment: "Keeps track whether the motorcycle has been sold")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Link);
                    table.ForeignKey(
                        name: "FK_Motorcycles_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motorcycles_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoldMotorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Cc = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle's engine displacement"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Motorcycle's price"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of announcement's addition to the database"),
                    DateSold = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of announcement's removal from the website")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldMotorcycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldMotorcycles_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoldMotorcycles_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketPrices_YearId",
                table: "MarketPrices",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MakeId",
                table: "Motorcycles",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_YearId",
                table: "Motorcycles",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldMotorcycles_MakeId",
                table: "SoldMotorcycles",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldMotorcycles_YearId",
                table: "SoldMotorcycles",
                column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketPrices");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "SoldMotorcycles");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
