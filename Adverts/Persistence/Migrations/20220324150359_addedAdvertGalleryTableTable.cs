using Microsoft.EntityFrameworkCore.Migrations;

namespace Adverts.Persistence.Migrations
{
    public partial class addedAdvertGalleryTableTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Adverts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdvertGallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertGallery_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertGallery_AdvertId",
                table: "AdvertGallery",
                column: "AdvertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertGallery");

            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Adverts");
        }
    }
}
