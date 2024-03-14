using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class UsedMotorcycleTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsedMotorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    DisplacementId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedMotorcycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedMotorcycles_Displacements_DisplacementId",
                        column: x => x.DisplacementId,
                        principalTable: "Displacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedMotorcycles_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedMotorcycles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedMotorcycles_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 8,
                column: "BrandId",
                value: 10);

            migrationBuilder.CreateIndex(
                name: "IX_UsedMotorcycles_DisplacementId",
                table: "UsedMotorcycles",
                column: "DisplacementId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedMotorcycles_MakeId",
                table: "UsedMotorcycles",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedMotorcycles_ModelId",
                table: "UsedMotorcycles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedMotorcycles_YearId",
                table: "UsedMotorcycles",
                column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsedMotorcycles");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 8,
                column: "BrandId",
                value: 2);
        }
    }
}
