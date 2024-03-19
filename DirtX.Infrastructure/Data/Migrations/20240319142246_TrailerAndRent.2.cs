using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class TrailerAndRent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Product",
                newName: "PartType");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Product",
                newName: "OilType");

            migrationBuilder.RenameColumn(
                name: "Oil_Type",
                table: "Product",
                newName: "GearType");

            migrationBuilder.RenameColumn(
                name: "Gear_Type",
                table: "Product",
                newName: "GearSize");

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    TrailerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    MaximumLoad = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.TrailerId);
                });

            migrationBuilder.CreateTable(
                name: "TrailersRents",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailerId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailersRents", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_TrailersRents_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "TrailerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 36,
                column: "GearSize",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "GearSize", "GearType" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 39,
                column: "GearType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 40,
                column: "GearType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "GearSize", "GearType" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "GearSize", "GearType" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "GearSize", "GearType" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "GearSize", "GearType" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "GearSize", "GearType" },
                values: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 29,
                column: "OilType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 30,
                column: "OilType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 31,
                column: "OilType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 32,
                column: "OilType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 33,
                column: "OilType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 34,
                column: "OilType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 35,
                column: "OilType",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_TrailersRents_TrailerId",
                table: "TrailersRents",
                column: "TrailerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailersRents");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.RenameColumn(
                name: "PartType",
                table: "Product",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "OilType",
                table: "Product",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "GearType",
                table: "Product",
                newName: "Oil_Type");

            migrationBuilder.RenameColumn(
                name: "GearSize",
                table: "Product",
                newName: "Gear_Type");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 39,
                column: "Size",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 40,
                column: "Size",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Size", "Gear_Type" },
                values: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 29,
                column: "Oil_Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 30,
                column: "Oil_Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 31,
                column: "Oil_Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 32,
                column: "Oil_Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 33,
                column: "Oil_Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 34,
                column: "Oil_Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 35,
                column: "Oil_Type",
                value: 2);
        }
    }
}
