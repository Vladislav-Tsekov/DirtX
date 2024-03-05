using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtX.Web.Data.Migrations
{
    public partial class ImgUrlBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearSpecifications_SpecificationTitles_TitleId",
                table: "GearSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_GearsProperties_GearSpecifications_SpecificationId",
                table: "GearsProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotoDisplacements_DisplacementId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotoMakes_MakeId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotoModels_ModelId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotoYears_YearId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_OilSpecifications_SpecificationTitles_TitleId",
                table: "OilSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_OilsProperties_OilSpecifications_SpecificationId",
                table: "OilsProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PartSpecifications_SpecificationTitles_TitleId",
                table: "PartSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PartsProperties_PartSpecifications_SpecificationId",
                table: "PartsProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartSpecifications",
                table: "PartSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OilSpecifications",
                table: "OilSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotoYears",
                table: "MotoYears");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotoModels",
                table: "MotoModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotoMakes",
                table: "MotoMakes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotoDisplacements",
                table: "MotoDisplacements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearSpecifications",
                table: "GearSpecifications");

            migrationBuilder.RenameTable(
                name: "PartSpecifications",
                newName: "PartsSpecifications");

            migrationBuilder.RenameTable(
                name: "OilSpecifications",
                newName: "OilsSpecifications");

            migrationBuilder.RenameTable(
                name: "MotoYears",
                newName: "Years");

            migrationBuilder.RenameTable(
                name: "MotoModels",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "MotoMakes",
                newName: "Makes");

            migrationBuilder.RenameTable(
                name: "MotoDisplacements",
                newName: "Displacements");

            migrationBuilder.RenameTable(
                name: "GearSpecifications",
                newName: "GearsSpecifications");

            migrationBuilder.RenameIndex(
                name: "IX_PartSpecifications_TitleId",
                table: "PartsSpecifications",
                newName: "IX_PartsSpecifications_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_OilSpecifications_TitleId",
                table: "OilsSpecifications",
                newName: "IX_OilsSpecifications_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_GearSpecifications_TitleId",
                table: "GearsSpecifications",
                newName: "IX_GearsSpecifications_TitleId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartsSpecifications",
                table: "PartsSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OilsSpecifications",
                table: "OilsSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Years",
                table: "Years",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Makes",
                table: "Makes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Displacements",
                table: "Displacements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearsSpecifications",
                table: "GearsSpecifications",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GearsProperties_GearsSpecifications_SpecificationId",
                table: "GearsProperties",
                column: "SpecificationId",
                principalTable: "GearsSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GearsSpecifications_SpecificationTitles_TitleId",
                table: "GearsSpecifications",
                column: "TitleId",
                principalTable: "SpecificationTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Displacements_DisplacementId",
                table: "Motorcycles",
                column: "DisplacementId",
                principalTable: "Displacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Makes_MakeId",
                table: "Motorcycles",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Models_ModelId",
                table: "Motorcycles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Years_YearId",
                table: "Motorcycles",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OilsProperties_OilsSpecifications_SpecificationId",
                table: "OilsProperties",
                column: "SpecificationId",
                principalTable: "OilsSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OilsSpecifications_SpecificationTitles_TitleId",
                table: "OilsSpecifications",
                column: "TitleId",
                principalTable: "SpecificationTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartsProperties_PartsSpecifications_SpecificationId",
                table: "PartsProperties",
                column: "SpecificationId",
                principalTable: "PartsSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartsSpecifications_SpecificationTitles_TitleId",
                table: "PartsSpecifications",
                column: "TitleId",
                principalTable: "SpecificationTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearsProperties_GearsSpecifications_SpecificationId",
                table: "GearsProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_GearsSpecifications_SpecificationTitles_TitleId",
                table: "GearsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Displacements_DisplacementId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Makes_MakeId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Models_ModelId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Years_YearId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_OilsProperties_OilsSpecifications_SpecificationId",
                table: "OilsProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OilsSpecifications_SpecificationTitles_TitleId",
                table: "OilsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PartsProperties_PartsSpecifications_SpecificationId",
                table: "PartsProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PartsSpecifications_SpecificationTitles_TitleId",
                table: "PartsSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Years",
                table: "Years");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartsSpecifications",
                table: "PartsSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OilsSpecifications",
                table: "OilsSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Makes",
                table: "Makes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearsSpecifications",
                table: "GearsSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Displacements",
                table: "Displacements");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductBrands");

            migrationBuilder.RenameTable(
                name: "Years",
                newName: "MotoYears");

            migrationBuilder.RenameTable(
                name: "PartsSpecifications",
                newName: "PartSpecifications");

            migrationBuilder.RenameTable(
                name: "OilsSpecifications",
                newName: "OilSpecifications");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "MotoModels");

            migrationBuilder.RenameTable(
                name: "Makes",
                newName: "MotoMakes");

            migrationBuilder.RenameTable(
                name: "GearsSpecifications",
                newName: "GearSpecifications");

            migrationBuilder.RenameTable(
                name: "Displacements",
                newName: "MotoDisplacements");

            migrationBuilder.RenameIndex(
                name: "IX_PartsSpecifications_TitleId",
                table: "PartSpecifications",
                newName: "IX_PartSpecifications_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_OilsSpecifications_TitleId",
                table: "OilSpecifications",
                newName: "IX_OilSpecifications_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_GearsSpecifications_TitleId",
                table: "GearSpecifications",
                newName: "IX_GearSpecifications_TitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotoYears",
                table: "MotoYears",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartSpecifications",
                table: "PartSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OilSpecifications",
                table: "OilSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotoModels",
                table: "MotoModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotoMakes",
                table: "MotoMakes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearSpecifications",
                table: "GearSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotoDisplacements",
                table: "MotoDisplacements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GearSpecifications_SpecificationTitles_TitleId",
                table: "GearSpecifications",
                column: "TitleId",
                principalTable: "SpecificationTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GearsProperties_GearSpecifications_SpecificationId",
                table: "GearsProperties",
                column: "SpecificationId",
                principalTable: "GearSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotoDisplacements_DisplacementId",
                table: "Motorcycles",
                column: "DisplacementId",
                principalTable: "MotoDisplacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotoMakes_MakeId",
                table: "Motorcycles",
                column: "MakeId",
                principalTable: "MotoMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotoModels_ModelId",
                table: "Motorcycles",
                column: "ModelId",
                principalTable: "MotoModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotoYears_YearId",
                table: "Motorcycles",
                column: "YearId",
                principalTable: "MotoYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OilSpecifications_SpecificationTitles_TitleId",
                table: "OilSpecifications",
                column: "TitleId",
                principalTable: "SpecificationTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OilsProperties_OilSpecifications_SpecificationId",
                table: "OilsProperties",
                column: "SpecificationId",
                principalTable: "OilSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartSpecifications_SpecificationTitles_TitleId",
                table: "PartSpecifications",
                column: "TitleId",
                principalTable: "SpecificationTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartsProperties_PartSpecifications_SpecificationId",
                table: "PartsProperties",
                column: "SpecificationId",
                principalTable: "PartSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
