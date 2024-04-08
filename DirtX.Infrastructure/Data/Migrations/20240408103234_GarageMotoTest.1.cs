using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Infrastructure.Migrations
{
    public partial class GarageMotoTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UsedMotorcycles",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                comment: "Used motorcycle description, containing information about the vehicle's condition.",
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldComment: "Used motorcycle description, containing information about the vehicle's condition.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UsedMotorcycles",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                comment: "Used motorcycle description, containing information about the vehicle's condition.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldComment: "Used motorcycle description, containing information about the vehicle's condition.");
        }
    }
}
