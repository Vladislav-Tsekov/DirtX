using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class ImgUrlsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.ibb.co/pRBhwQL/Brand-Alpinestars.jpg");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://i.ibb.co/QJVYPT5/Brand-Belray.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.ibb.co/8XQjB28/Brand-Boyesen.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.ibb.co/FHZw9Kn/Brand-DID.jpg");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.ibb.co/2kwbTSB/Brand-Galfer.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.ibb.co/JHRM0wR/Brand-Hiflofiltro.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i.ibb.co/6P8X0rw/Brand-Hinson.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://i.ibb.co/rb39ScR/Brand-KYB.jpg");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://i.ibb.co/BTH07X5/Brand-Motorex.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://i.ibb.co/GCr2RWB/Brand-Motul.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://i.ibb.co/wYHcP3V/Brand-Moto-Master.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://i.ibb.co/LPmhfCZ/Brand-NGK.jpg");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://i.ibb.co/mcTTcvw/Brand-Oneal.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://i.ibb.co/Hq2m8dJ/Brand-Showa.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://i.ibb.co/brNJbzM/Brand-Thor.jpg");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://i.ibb.co/SVDTgZW/Brand-Twin-Air.png");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://i.ibb.co/ggg74HP/Brand-Vertex.gif");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://i.ibb.co/c2BQ2n7/Brand-Wiseco.gif");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://i.ibb.co/8403f2t/Brand-Yamalube.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1FxMePAAWfcIuzJXsNkyLGXc72SarzT9w/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1Q7eHGc39Nu74JiQ9xAGXT_U6PyYt_3AA/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/18V7aJGhpLDHahDCZXkUj3ba1EC4yRAt1/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1u_AMDYAvMITYvJ5gvvBQvSoXCdWzy4Fn/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1vqoUtU3jktoXdRLUVy2hy8BNM9NIKsIH/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1pfA43ItMESpKjcNFkt9mPxPfFsuBGIek/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1vM-q7GziWJ0QPM9DvCtHou0IeFB2V09x/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1v9HysbXJIFiRPjNNRmk0WuIDFGu9s7vd/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1OQEWGCcm1Nu86_gnPJsFBig1BirU-FPK/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1fiWhSD1H8Ey86z-EA2R7kGqnaq8P_g1J/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/17WA4ruim_w_0d4NZYFkqZBQxD8YCRrRh/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1M0Ueez4o-I1lL8b0b1I3o-01cCoFjSvs/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1wp9VbB7HEyXBwEdBLcifwDXOQF0z8jo7/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1ZB6Dwt_HLf3POFZzqnD0a3HXxubUJcW7/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1wfLhkB71NPVcHwN-arQzM1rMHEM5Tw0W/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/147cA1lxAaTuhfO-kyAP1a4tj94rmnqme/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1aXRZrZDsliYeRI_Rc3VnvRAa8pxbeq9f/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1fSttXdhGap4aN91KiHXoK4Y99aNUpQLD/view?usp=drive_link");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://drive.google.com/file/d/1py97QclS3g4hys_ah5hUqzyrH9VwPFcH/view?usp=drive_link");
        }
    }
}
