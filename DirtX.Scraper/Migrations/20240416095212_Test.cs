using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Scraper.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cc",
                table: "SoldMotorcycles",
                newName: "Displacement");

            migrationBuilder.CreateTable(
                name: "ScraperInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastRunDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScraperInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScraperInfo");

            migrationBuilder.RenameColumn(
                name: "Displacement",
                table: "SoldMotorcycles",
                newName: "Cc");
        }
    }
}
