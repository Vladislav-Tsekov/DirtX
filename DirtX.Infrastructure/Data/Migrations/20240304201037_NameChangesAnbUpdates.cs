using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class NameChangesAnbUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "MotoModels");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "MotoMakes");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "MotoYears",
                newName: "ManufactureYear");

            migrationBuilder.RenameColumn(
                name: "Displacement",
                table: "MotoDisplacements",
                newName: "Volume");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MotoModels",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MotoMakes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Yamaha");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Honda");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Suzuki");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Kawasaki");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "KTM");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Husqvarna");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "GASGAS");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "YZ-F");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "CRF");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "RM-Z");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "KX-F");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "SX-F");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "FC");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "MC-F");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "MotoModels");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MotoMakes");

            migrationBuilder.RenameColumn(
                name: "ManufactureYear",
                table: "MotoYears",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Volume",
                table: "MotoDisplacements",
                newName: "Displacement");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "MotoModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "MotoMakes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Make",
                value: "Yamaha");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Make",
                value: "Honda");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Make",
                value: "Suzuki");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Make",
                value: "Kawasaki");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Make",
                value: "KTM");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Make",
                value: "Husqvarna");

            migrationBuilder.UpdateData(
                table: "MotoMakes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Make",
                value: "GASGAS");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Model",
                value: "YZ-F");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Model",
                value: "CRF");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Model",
                value: "RM-Z");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Model",
                value: "KX-F");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Model",
                value: "SX-F");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Model",
                value: "FC");

            migrationBuilder.UpdateData(
                table: "MotoModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Model",
                value: "MC-F");
        }
    }
}
