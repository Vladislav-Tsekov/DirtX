using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class ProdSpecSeedUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductsSpecifications",
                columns: new[] { "ProductId", "SpecificationId" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 9, 3 },
                    { 9, 14 },
                    { 11, 1 },
                    { 11, 3 },
                    { 11, 16 },
                    { 12, 13 },
                    { 13, 4 },
                    { 14, 1 },
                    { 14, 15 },
                    { 15, 6 },
                    { 15, 26 },
                    { 16, 6 },
                    { 16, 25 },
                    { 17, 24 },
                    { 18, 23 },
                    { 19, 27 },
                    { 20, 24 },
                    { 21, 6 },
                    { 24, 1 },
                    { 25, 1 },
                    { 27, 4 },
                    { 27, 6 },
                    { 29, 31 },
                    { 30, 30 },
                    { 31, 29 },
                    { 33, 30 },
                    { 35, 30 },
                    { 36, 10 },
                    { 38, 16 },
                    { 39, 16 },
                    { 40, 9 },
                    { 40, 10 },
                    { 40, 15 },
                    { 40, 32 },
                    { 41, 12 },
                    { 41, 15 },
                    { 41, 32 },
                    { 43, 16 },
                    { 44, 12 },
                    { 45, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 9, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 11, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 14, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 15, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 16, 25 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 17, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 18, 23 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 19, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 20, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 21, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 27, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 27, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 29, 31 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 30, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 31, 29 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 33, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 35, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 36, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 38, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 39, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 40, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 40, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 40, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 40, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 41, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 41, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 41, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 43, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 44, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 45, 10 });
        }
    }
}
