using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class TestInitialPropsMTMProds : Migration
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
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_OilSpecifications_TitleId",
                table: "OilSpecifications",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_OilsProperties_SpecificationId",
                table: "OilsProperties",
                column: "SpecificationId");

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
                name: "OilsProperties");

            migrationBuilder.DropTable(
                name: "PartsProperties");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "GearSpecifications");

            migrationBuilder.DropTable(
                name: "OilSpecifications");

            migrationBuilder.DropTable(
                name: "PartSpecifications");

            migrationBuilder.DropTable(
                name: "SpecificationTitles");

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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
