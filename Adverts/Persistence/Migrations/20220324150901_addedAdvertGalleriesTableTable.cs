using Microsoft.EntityFrameworkCore.Migrations;

namespace Adverts.Persistence.Migrations
{
    public partial class addedAdvertGalleriesTableTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertGallery_Adverts_AdvertId",
                table: "AdvertGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertGallery",
                table: "AdvertGallery");

            migrationBuilder.RenameTable(
                name: "AdvertGallery",
                newName: "AdvertGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertGallery_AdvertId",
                table: "AdvertGalleries",
                newName: "IX_AdvertGalleries_AdvertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertGalleries",
                table: "AdvertGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertGalleries_Adverts_AdvertId",
                table: "AdvertGalleries",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertGalleries_Adverts_AdvertId",
                table: "AdvertGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertGalleries",
                table: "AdvertGalleries");

            migrationBuilder.RenameTable(
                name: "AdvertGalleries",
                newName: "AdvertGallery");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertGalleries_AdvertId",
                table: "AdvertGallery",
                newName: "IX_AdvertGallery_AdvertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertGallery",
                table: "AdvertGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertGallery_Adverts_AdvertId",
                table: "AdvertGallery",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
