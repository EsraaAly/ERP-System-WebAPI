using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTable_StoreCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreCategory",
                table: "Stores");

            migrationBuilder.AddColumn<int>(
                name: "StoreCategoryId",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreCategoryId1",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StoreCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryNameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreCategoryId",
                table: "Stores",
                column: "StoreCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreCategoryId1",
                table: "Stores",
                column: "StoreCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategories_CategoryName",
                table: "StoreCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreCategories_StoreCategoryId",
                table: "Stores",
                column: "StoreCategoryId",
                principalTable: "StoreCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreCategories_StoreCategoryId1",
                table: "Stores",
                column: "StoreCategoryId1",
                principalTable: "StoreCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreCategories_StoreCategoryId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreCategories_StoreCategoryId1",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "StoreCategories");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StoreCategoryId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StoreCategoryId1",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreCategoryId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreCategoryId1",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "StoreCategory",
                table: "Stores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
