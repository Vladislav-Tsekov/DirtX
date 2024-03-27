using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class DbOverhaul2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductCategory");

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Welcome to our dirt bike parts section, your destination for all your off-road riding needs! Whether you're in need of replacement parts or looking to upgrade your dirt bike's performance, we've got you covered. Browse through our extensive collection of high-quality parts, including pistons, chains, sprockets, suspension components, and brake elements. Each product is carefully selected to ensure durability, reliability, and compatibility with a wide range of dirt bike models. With our comprehensive selection and competitive prices, maintaining and enhancing your dirt bike has never been easier. Shop now and get ready to take your off-road adventures to the next level!", "Part" },
                    { 2, "Welcome to our motorcycle oils and lubricants section, your destination for keeping your bike running smoothly and efficiently! Whether you're a weekend cruiser or a seasoned racer, maintaining your motorcycle's performance is essential, and we're here to help. Explore our wide range of high-quality motor oils, suspension oils, coolants, and lubricants, meticulously crafted to meet the demands of your machine. From premium synthetic blends to specialized formulas designed for specific applications, we have everything you need to keep your engine running at its best. Our selection of lubricants ensures smooth operation of vital components, while our range of coolants helps regulate engine temperature for optimal performance. With our products, you can trust that your motorcycle is in good hands, allowing you to focus on the thrill of the ride. Browse our collection now and experience the difference that quality oils and lubricants can make for your motorcycle.", "Oil" },
                    { 3, "Step into the world of riding equipment, where safety meets style! Our riding gear section is your go-to destination for all things moto-apparel and accessories. We've got you covered from head to toe. Explore our collection of outfits, helmets, protective gear, boots, and accessories designed to enhance your riding experience. Choose from a variety of helmets, each engineered for maximum safety and performance, while our selection of protective gear ensures you ride with confidence. Slip into a pair of premium riding boots, crafted for superior grip and stability, and accessorize with our range of must-have extras, from gloves to goggles. With our riding gear, you can ride in style while staying safe and comfortable on every journey. Explore our collection today and gear up for your next adventure on two wheels!", "Gear" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationTitles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 8, "Package" },
                    { 9, "Size" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "TitleId", "Value" },
                values: new object[,]
                {
                    { 34, 8, "1L" },
                    { 35, 8, "4L" },
                    { 36, 8, "0.5L" },
                    { 37, 8, "0.75L" },
                    { 38, 8, "S" },
                    { 39, 8, "M" },
                    { 40, 8, "L" },
                    { 41, 8, "43" },
                    { 42, 8, "45" }
                });

            migrationBuilder.InsertData(
                table: "ProductsSpecifications",
                columns: new[] { "ProductId", "SpecificationId" },
                values: new object[,]
                {
                    { 28, 34 },
                    { 29, 34 },
                    { 30, 35 },
                    { 31, 34 },
                    { 32, 37 },
                    { 33, 34 },
                    { 34, 34 },
                    { 35, 34 },
                    { 36, 39 },
                    { 37, 40 },
                    { 40, 38 },
                    { 41, 39 },
                    { 42, 41 },
                    { 43, 42 },
                    { 45, 40 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 28, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 29, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 30, 35 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 31, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 32, 37 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 33, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 34, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 35, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 36, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 37, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 40, 38 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 41, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 42, 41 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 43, 42 });

            migrationBuilder.DeleteData(
                table: "ProductsSpecifications",
                keyColumns: new[] { "ProductId", "SpecificationId" },
                keyValues: new object[] { 45, 40 });

            migrationBuilder.DeleteData(
                table: "SpecificationTitles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SpecificationTitles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
