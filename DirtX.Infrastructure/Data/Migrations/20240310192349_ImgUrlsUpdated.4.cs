using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class ImgUrlsUpdated4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Oils",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Gears",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.ibb.co/rs2c1Pd/Gear-SM5-Helmet.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://i.ibb.co/YkHnz4F/Gear-3-Series-Oneal.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/RhPrZB3/Gear-Bionic-Action.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.ibb.co/JrJSf2y/Gear-Asterix-Knee.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.ibb.co/bRsz5gz/Gear-Jersey-50th.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.ibb.co/hcZKcsB/Gear-Thor-Outfit.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i.ibb.co/pzGDVTv/Gear-Tech10-Boots.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://i.ibb.co/34RRszr/Gear-Blitz-Thor.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://i.ibb.co/sHzPG34/Gear-B20-Goggles.jpg");

            migrationBuilder.UpdateData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://i.ibb.co/4Rf2r40/Gear-Element-Gloves.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.ibb.co/Cm7S8dG/Oil-Cross-Power-2-T.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://i.ibb.co/9Nyc55B/Oil-Motul-300-V-1-L.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/3ywBxpQ/Oil-Motul-300-V-4-L.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.ibb.co/W52svBD/Oil-Bel-Ray-Fork-5-W.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.ibb.co/f1fW4j5/Oil-Motorex-Shock-Oil.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.ibb.co/2dRRzHy/Oil-Yamalube-10w40.jpg");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The most efficient coolant on the market.", "https://i.ibb.co/9rgYKcv/Oil-Motul-Antifreeze.jpg", "AutoCool -35°C 1L" });

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.ibb.co/jTnS3W0/Part-High-Comp-Piston.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://i.ibb.co/m6fQKSx/Part-Forged-Piston.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/1RXqkVy/Part-Engine-Cover.png");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.ibb.co/Yj4MJ6r/Part-Top-End-Gasket.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.ibb.co/ZHQ36hf/Part-Water-Pump-Cover.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.ibb.co/dmkcV30/Part-Fuel-Injector.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i.ibb.co/fG9XLdn/Part-Intake-Valves.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://i.ibb.co/LnW1Y4k/Part-Fuel-Pump.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://i.ibb.co/vqg672F/Part-Air-Filter.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://i.ibb.co/kG1KnVN/Part-Oil-Filter.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://i.ibb.co/V2qj6c0/Part-Oil-Filter-Cap.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal.", "https://i.ibb.co/s1YdYwt/Part-Fuel-Filter-Tank.jpg" });

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://i.ibb.co/tc2m4jh/Part-Brake-Pads.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://i.ibb.co/1RqcRGm/Part-Brake-Lever.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://i.ibb.co/DG6HpM4/Part-Front-Brake-Disc.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://i.ibb.co/BNPMF26/Part-Rear-Brake-Disc.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://i.ibb.co/LRQphRW/Part-Shock-Absorber.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://i.ibb.co/yyZK9tT/Part-Fork-Springs.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://i.ibb.co/7jy1dvG/Part-Fork-Seals.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://i.ibb.co/LtFwYZ3/Part-KYB-Shock.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "https://i.ibb.co/VCWrYtY/Part-Steering-Bearings.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "https://i.ibb.co/9tCHFWY/Part-Chain.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "https://i.ibb.co/9tCHFWY/Part-Chain.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "https://i.ibb.co/xGz2dVn/Part-Rear-Sprocket.png");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "https://i.ibb.co/9pKtqn6/Part-Front-Sprocket.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "https://i.ibb.co/y0KwgV5/Part-Clutch-Kit.jpg");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "https://i.ibb.co/9qGztRG/Part-Clutch-Plates.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Oils");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Gears");

            migrationBuilder.UpdateData(
                table: "Oils",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The baseline 4-stroke engine oil for motorcycles.", "MotoCool -35°C 1L" });

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal");
        }
    }
}
