using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rewinery.Server.Core.Migrations
{
    public partial class CellarFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CellarRentals_Cellars_CellarId",
                table: "CellarRentals");

            migrationBuilder.AlterColumn<int>(
                name: "CellarId",
                table: "CellarRentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CellarRentals_Cellars_CellarId",
                table: "CellarRentals",
                column: "CellarId",
                principalTable: "Cellars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CellarRentals_Cellars_CellarId",
                table: "CellarRentals");

            migrationBuilder.AlterColumn<int>(
                name: "CellarId",
                table: "CellarRentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CellarRentals_Cellars_CellarId",
                table: "CellarRentals",
                column: "CellarId",
                principalTable: "Cellars",
                principalColumn: "Id");
        }
    }
}
