using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConvertStringPropertiesToForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPriceLists_Clients_ClientID",
                table: "ClientPriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierItems_Suppliers_SupplierID",
                table: "SupplierItems");

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "SupplierItems");

            migrationBuilder.DropColumn(
                name: "ClientType",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "ClientPriceLists");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ClientPriceLists");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "SupplierItems",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierItems_SupplierID",
                table: "SupplierItems",
                newName: "IX_SupplierItems_SupplierId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "ClientPriceLists",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ItemSNo",
                table: "ClientPriceLists",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientPriceLists_ClientID",
                table: "ClientPriceLists",
                newName: "IX_ClientPriceLists_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierName",
                table: "SupplierItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "SupplierItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryId",
                table: "SupplierItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId1",
                table: "SupplierItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientTypeId",
                table: "ItemRegistries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemRegistries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "ItemRegistries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "ItemRegistries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Sales",
                table: "ItemLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MinimumLevel",
                table: "ItemLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemOrder",
                table: "ItemLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "ItemLists",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryId",
                table: "ItemLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "ItemLists",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "ClientPriceLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryId",
                table: "ClientPriceLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItems_ItemCategoryId",
                table: "SupplierItems",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItems_SupplierId1",
                table: "SupplierItems",
                column: "SupplierId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRegistries_ClientTypeId",
                table: "ItemRegistries",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRegistries_ItemId",
                table: "ItemRegistries",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRegistries_RegionId",
                table: "ItemRegistries",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRegistries_StoreId",
                table: "ItemRegistries",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLists_ItemCategoryId",
                table: "ItemLists",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLists_UnitId",
                table: "ItemLists",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPriceLists_ClientId1",
                table: "ClientPriceLists",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPriceLists_ItemCategoryId",
                table: "ClientPriceLists",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPriceLists_ItemId",
                table: "ClientPriceLists",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPriceLists_Clients_ClientId",
                table: "ClientPriceLists",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPriceLists_Clients_ClientId1",
                table: "ClientPriceLists",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPriceLists_ItemCategories_ItemCategoryId",
                table: "ClientPriceLists",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPriceLists_ItemLists_ItemId",
                table: "ClientPriceLists",
                column: "ItemId",
                principalTable: "ItemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLists_ItemCategories_ItemCategoryId",
                table: "ItemLists",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLists_Units_UnitId",
                table: "ItemLists",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRegistries_ClientTypes_ClientTypeId",
                table: "ItemRegistries",
                column: "ClientTypeId",
                principalTable: "ClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRegistries_ItemLists_ItemId",
                table: "ItemRegistries",
                column: "ItemId",
                principalTable: "ItemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRegistries_Regions_RegionId",
                table: "ItemRegistries",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRegistries_Stores_StoreId",
                table: "ItemRegistries",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierItems_ItemCategories_ItemCategoryId",
                table: "SupplierItems",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierItems_Suppliers_SupplierId",
                table: "SupplierItems",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierItems_Suppliers_SupplierId1",
                table: "SupplierItems",
                column: "SupplierId1",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPriceLists_Clients_ClientId",
                table: "ClientPriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPriceLists_Clients_ClientId1",
                table: "ClientPriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPriceLists_ItemCategories_ItemCategoryId",
                table: "ClientPriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPriceLists_ItemLists_ItemId",
                table: "ClientPriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLists_ItemCategories_ItemCategoryId",
                table: "ItemLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLists_Units_UnitId",
                table: "ItemLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRegistries_ClientTypes_ClientTypeId",
                table: "ItemRegistries");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRegistries_ItemLists_ItemId",
                table: "ItemRegistries");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRegistries_Regions_RegionId",
                table: "ItemRegistries");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRegistries_Stores_StoreId",
                table: "ItemRegistries");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierItems_ItemCategories_ItemCategoryId",
                table: "SupplierItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierItems_Suppliers_SupplierId",
                table: "SupplierItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierItems_Suppliers_SupplierId1",
                table: "SupplierItems");

            migrationBuilder.DropIndex(
                name: "IX_SupplierItems_ItemCategoryId",
                table: "SupplierItems");

            migrationBuilder.DropIndex(
                name: "IX_SupplierItems_SupplierId1",
                table: "SupplierItems");

            migrationBuilder.DropIndex(
                name: "IX_ItemRegistries_ClientTypeId",
                table: "ItemRegistries");

            migrationBuilder.DropIndex(
                name: "IX_ItemRegistries_ItemId",
                table: "ItemRegistries");

            migrationBuilder.DropIndex(
                name: "IX_ItemRegistries_RegionId",
                table: "ItemRegistries");

            migrationBuilder.DropIndex(
                name: "IX_ItemRegistries_StoreId",
                table: "ItemRegistries");

            migrationBuilder.DropIndex(
                name: "IX_ItemLists_ItemCategoryId",
                table: "ItemLists");

            migrationBuilder.DropIndex(
                name: "IX_ItemLists_UnitId",
                table: "ItemLists");

            migrationBuilder.DropIndex(
                name: "IX_ClientPriceLists_ClientId1",
                table: "ClientPriceLists");

            migrationBuilder.DropIndex(
                name: "IX_ClientPriceLists_ItemCategoryId",
                table: "ClientPriceLists");

            migrationBuilder.DropIndex(
                name: "IX_ClientPriceLists_ItemId",
                table: "ClientPriceLists");

            migrationBuilder.DropColumn(
                name: "ItemCategoryId",
                table: "SupplierItems");

            migrationBuilder.DropColumn(
                name: "SupplierId1",
                table: "SupplierItems");

            migrationBuilder.DropColumn(
                name: "ClientTypeId",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ItemRegistries");

            migrationBuilder.DropColumn(
                name: "ItemCategoryId",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "ClientPriceLists");

            migrationBuilder.DropColumn(
                name: "ItemCategoryId",
                table: "ClientPriceLists");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "SupplierItems",
                newName: "SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierItems_SupplierId",
                table: "SupplierItems",
                newName: "IX_SupplierItems_SupplierID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientPriceLists",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ClientPriceLists",
                newName: "ItemSNo");

            migrationBuilder.RenameIndex(
                name: "IX_ClientPriceLists_ClientId",
                table: "ClientPriceLists",
                newName: "IX_ClientPriceLists_ClientID");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierName",
                table: "SupplierItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "SupplierItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "SupplierItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientType",
                table: "ItemRegistries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "ItemRegistries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ItemRegistries",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ItemRegistries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sales",
                table: "ItemLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinimumLevel",
                table: "ItemLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemOrder",
                table: "ItemLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "ItemLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ItemLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ItemLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "ClientPriceLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ClientPriceLists",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPriceLists_Clients_ClientID",
                table: "ClientPriceLists",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierItems_Suppliers_SupplierID",
                table: "SupplierItems",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
