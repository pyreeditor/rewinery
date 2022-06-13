using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rewinery.Server.Core.Migrations
{
    public partial class Cellar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentResponses_ReceiptComments_CommentId",
                table: "CommentResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WineReceipts_WineId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ReceiptComments");

            migrationBuilder.DropTable(
                name: "WineReceipts");

            migrationBuilder.CreateTable(
                name: "Cellars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineRecipes_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineRecipes_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CellarRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    StartRental = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndRental = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CellarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellarRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellarRentals_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CellarRentals_Cellars_CellarId",
                        column: x => x.CellarId,
                        principalTable: "Cellars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CellarRentals_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeComments_WineRecipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "WineRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CellarRentals_CellarId",
                table: "CellarRentals",
                column: "CellarId");

            migrationBuilder.CreateIndex(
                name: "IX_CellarRentals_OwnerId",
                table: "CellarRentals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CellarRentals_WineId",
                table: "CellarRentals",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeComments_RecipeId",
                table: "RecipeComments",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeComments_UserId",
                table: "RecipeComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WineRecipes_OwnerId",
                table: "WineRecipes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WineRecipes_WineId",
                table: "WineRecipes",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentResponses_RecipeComments_CommentId",
                table: "CommentResponses",
                column: "CommentId",
                principalTable: "RecipeComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WineRecipes_WineId",
                table: "Orders",
                column: "WineId",
                principalTable: "WineRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentResponses_RecipeComments_CommentId",
                table: "CommentResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WineRecipes_WineId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CellarRentals");

            migrationBuilder.DropTable(
                name: "RecipeComments");

            migrationBuilder.DropTable(
                name: "Cellars");

            migrationBuilder.DropTable(
                name: "WineRecipes");

            migrationBuilder.CreateTable(
                name: "WineReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineReceipts_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WineReceipts_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    WineReceiptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceiptComments_WineReceipts_WineReceiptId",
                        column: x => x.WineReceiptId,
                        principalTable: "WineReceipts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptComments_UserId",
                table: "ReceiptComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptComments_WineReceiptId",
                table: "ReceiptComments",
                column: "WineReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_WineReceipts_OwnerId",
                table: "WineReceipts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WineReceipts_WineId",
                table: "WineReceipts",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentResponses_ReceiptComments_CommentId",
                table: "CommentResponses",
                column: "CommentId",
                principalTable: "ReceiptComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WineReceipts_WineId",
                table: "Orders",
                column: "WineId",
                principalTable: "WineReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
