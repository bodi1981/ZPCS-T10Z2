using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adverts.Persistence.Migrations
{
    public partial class AddedColumnsToAdvertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Adverts");

            migrationBuilder.AddColumn<int>(
                name: "ConditionId",
                table: "Adverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateValid",
                table: "Adverts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ConditionId",
                table: "Adverts",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Condition_ConditionId",
                table: "Adverts",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Condition_ConditionId",
                table: "Adverts");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_ConditionId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "DateValid",
                table: "Adverts");

            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
