using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class SeedMtmTablesTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GearsProperties",
                columns: new[] { "GearId", "SpecificationId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 2, 8 },
                    { 5, 1 },
                    { 5, 9 },
                    { 6, 1 },
                    { 6, 5 },
                    { 7, 8 },
                    { 8, 7 },
                    { 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 6 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 2, 2 },
                    { 2, 6 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 6 },
                    { 3, 9 },
                    { 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 3, 22 },
                    { 3, 23 },
                    { 3, 24 },
                    { 3, 25 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 7 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 24 },
                    { 4, 25 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 7 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 12 },
                    { 5, 13 },
                    { 5, 15 },
                    { 5, 16 },
                    { 5, 17 },
                    { 5, 18 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 5, 25 },
                    { 6, 2 },
                    { 6, 9 },
                    { 6, 10 },
                    { 6, 12 },
                    { 6, 13 },
                    { 6, 15 },
                    { 6, 16 },
                    { 6, 17 },
                    { 6, 18 },
                    { 6, 21 },
                    { 6, 22 },
                    { 6, 23 },
                    { 6, 24 },
                    { 6, 25 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 4 },
                    { 7, 9 },
                    { 7, 10 },
                    { 7, 12 },
                    { 7, 13 },
                    { 7, 15 },
                    { 7, 16 },
                    { 7, 18 },
                    { 7, 19 },
                    { 7, 22 },
                    { 7, 23 },
                    { 7, 24 },
                    { 7, 25 },
                    { 8, 2 },
                    { 8, 4 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 12 },
                    { 8, 13 },
                    { 8, 15 },
                    { 8, 16 },
                    { 8, 18 },
                    { 8, 19 },
                    { 8, 22 },
                    { 8, 23 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 8, 24 },
                    { 8, 25 },
                    { 9, 2 },
                    { 9, 4 },
                    { 9, 9 },
                    { 9, 10 },
                    { 9, 12 },
                    { 9, 13 },
                    { 9, 15 },
                    { 9, 16 },
                    { 9, 18 },
                    { 9, 19 },
                    { 9, 22 },
                    { 9, 23 },
                    { 9, 24 },
                    { 9, 25 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 9 },
                    { 10, 10 },
                    { 10, 11 },
                    { 10, 12 },
                    { 10, 13 },
                    { 10, 15 },
                    { 10, 16 },
                    { 10, 18 },
                    { 10, 22 },
                    { 10, 23 },
                    { 10, 24 },
                    { 10, 25 },
                    { 11, 2 },
                    { 11, 9 },
                    { 11, 10 },
                    { 11, 11 },
                    { 11, 12 },
                    { 11, 13 },
                    { 11, 15 },
                    { 11, 16 },
                    { 11, 18 },
                    { 11, 22 },
                    { 11, 23 },
                    { 11, 24 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 11, 25 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 9 },
                    { 12, 10 },
                    { 12, 11 },
                    { 12, 12 },
                    { 12, 13 },
                    { 12, 15 },
                    { 12, 16 },
                    { 12, 18 },
                    { 12, 22 },
                    { 12, 23 },
                    { 12, 24 },
                    { 12, 25 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 5 },
                    { 13, 9 },
                    { 13, 10 },
                    { 13, 12 },
                    { 13, 15 },
                    { 13, 16 },
                    { 13, 18 },
                    { 13, 22 },
                    { 13, 23 },
                    { 13, 24 },
                    { 13, 25 },
                    { 13, 27 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 5 },
                    { 14, 9 },
                    { 14, 10 },
                    { 14, 12 },
                    { 14, 15 },
                    { 14, 16 },
                    { 14, 18 },
                    { 14, 22 },
                    { 14, 23 },
                    { 14, 24 },
                    { 14, 25 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 14, 27 },
                    { 15, 2 },
                    { 15, 3 },
                    { 15, 5 },
                    { 15, 9 },
                    { 15, 10 },
                    { 15, 12 },
                    { 15, 15 },
                    { 15, 16 },
                    { 15, 18 },
                    { 15, 22 },
                    { 15, 23 },
                    { 15, 24 },
                    { 15, 25 },
                    { 15, 27 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 5 },
                    { 16, 9 },
                    { 16, 10 },
                    { 16, 12 },
                    { 16, 14 },
                    { 16, 15 },
                    { 16, 16 },
                    { 16, 18 },
                    { 16, 22 },
                    { 16, 23 },
                    { 16, 24 },
                    { 16, 25 },
                    { 16, 26 },
                    { 17, 2 },
                    { 17, 3 },
                    { 17, 5 },
                    { 17, 9 },
                    { 17, 10 },
                    { 17, 12 },
                    { 17, 14 },
                    { 17, 15 },
                    { 17, 16 },
                    { 17, 18 },
                    { 17, 22 },
                    { 17, 23 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[,]
                {
                    { 17, 24 },
                    { 17, 25 },
                    { 17, 26 },
                    { 18, 2 },
                    { 18, 3 },
                    { 18, 5 },
                    { 18, 9 },
                    { 18, 10 },
                    { 18, 12 },
                    { 18, 14 },
                    { 18, 15 },
                    { 18, 16 },
                    { 18, 18 },
                    { 18, 22 },
                    { 18, 23 },
                    { 18, 24 },
                    { 18, 25 },
                    { 19, 2 },
                    { 19, 3 },
                    { 19, 8 },
                    { 19, 9 },
                    { 19, 10 },
                    { 19, 12 },
                    { 19, 15 },
                    { 19, 16 },
                    { 19, 18 },
                    { 19, 22 },
                    { 19, 23 },
                    { 19, 24 },
                    { 19, 25 },
                    { 20, 2 },
                    { 20, 3 },
                    { 20, 8 },
                    { 20, 9 },
                    { 20, 10 },
                    { 20, 12 },
                    { 20, 15 },
                    { 20, 16 },
                    { 20, 18 },
                    { 20, 22 },
                    { 20, 23 },
                    { 20, 24 }
                });

            migrationBuilder.InsertData(
                table: "MotorcyclesParts",
                columns: new[] { "MotorcycleId", "PartId" },
                values: new object[] { 20, 25 });

            migrationBuilder.InsertData(
                table: "OilsProperties",
                columns: new[] { "OilId", "SpecificationId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 3 },
                    { 2, 6 },
                    { 3, 2 },
                    { 3, 6 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 6, 5 },
                    { 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "PartsProperties",
                columns: new[] { "PartId", "SpecificationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 8 },
                    { 1, 16 },
                    { 2, 1 },
                    { 2, 7 },
                    { 2, 21 },
                    { 3, 2 },
                    { 3, 14 },
                    { 5, 6 },
                    { 5, 15 },
                    { 7, 2 },
                    { 7, 8 },
                    { 9, 3 },
                    { 10, 9 },
                    { 11, 15 },
                    { 13, 4 },
                    { 13, 6 },
                    { 14, 1 },
                    { 14, 14 },
                    { 15, 26 },
                    { 16, 25 },
                    { 17, 11 },
                    { 17, 24 },
                    { 18, 1 },
                    { 18, 23 },
                    { 19, 27 },
                    { 20, 10 },
                    { 20, 23 },
                    { 22, 6 },
                    { 22, 14 },
                    { 23, 6 }
                });

            migrationBuilder.InsertData(
                table: "PartsProperties",
                columns: new[] { "PartId", "SpecificationId" },
                values: new object[,]
                {
                    { 23, 14 },
                    { 24, 1 },
                    { 24, 15 },
                    { 25, 1 },
                    { 25, 13 },
                    { 27, 4 },
                    { 27, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "GearsProperties",
                keyColumns: new[] { "GearId", "SpecificationId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 19 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 20 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 21 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 21 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 6, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 7, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 8, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 19 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 9, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 10, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 11, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 11 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 12, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 13, 27 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 14, 27 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 15, 27 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 14 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 16, 26 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 5 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 14 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 17, 26 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 5 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 14 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 18, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 8 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 19, 25 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 8 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 9 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 10 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 12 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 15 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 16 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 18 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 22 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 23 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 24 });

            migrationBuilder.DeleteData(
                table: "MotorcyclesParts",
                keyColumns: new[] { "MotorcycleId", "PartId" },
                keyValues: new object[] { 20, 25 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "OilsProperties",
                keyColumns: new[] { "OilId", "SpecificationId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 11, 15 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 13, 6 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 15, 26 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 16, 25 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 17, 11 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 17, 24 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 18, 23 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 19, 27 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 20, 10 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 20, 23 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 22, 14 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 23, 6 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 23, 14 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 24, 15 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 25, 13 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 27, 4 });

            migrationBuilder.DeleteData(
                table: "PartsProperties",
                keyColumns: new[] { "PartId", "SpecificationId" },
                keyValues: new object[] { 27, 6 });
        }
    }
}
