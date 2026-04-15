using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSupplierRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AccNo",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CR",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_VATNo",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "ItemSNo",
                table: "ClientPriceLists",
                newName: "ItemId");

            migrationBuilder.AlterColumn<string>(
                name: "VATNo",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fax",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Suppliers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "CR",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AccNo",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryId",
                table: "SupplierItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "SupplierItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "ItemCategoryId",
                table: "ClientPriceLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AccNo",
                table: "Suppliers",
                column: "AccNo",
                unique: true,
                filter: "[AccNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CR",
                table: "Suppliers",
                column: "CR",
                unique: true,
                filter: "[CR] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_VATNo",
                table: "Suppliers",
                column: "VATNo",
                unique: true,
                filter: "[VATNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItems_ItemCategoryId",
                table: "SupplierItems",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItems_ItemId",
                table: "SupplierItems",
                column: "ItemId");

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
                name: "IX_ClientPriceLists_ItemCategoryId",
                table: "ClientPriceLists",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPriceLists_ItemId",
                table: "ClientPriceLists",
                column: "ItemId");

            // Data Migration Logic to prevent FK conflicts
            migrationBuilder.Sql(@"
                -- Ensure default lookup values exist
                IF NOT EXISTS (SELECT 1 FROM ItemCategories) INSERT INTO ItemCategories (ItemCategoryName, AccNo, AccName, CreatedBy, CreatedDate, IsDeleted) VALUES ('Default', '0', 'Default', 'System', GETUTCDATE(), 0);
                IF NOT EXISTS (SELECT 1 FROM Units) INSERT INTO Units (UnitName, CreatedBy, CreatedDate, IsDeleted) VALUES ('Default', 'System', GETUTCDATE(), 0);
                IF NOT EXISTS (SELECT 1 FROM ClientTypes) INSERT INTO ClientTypes (Type, CreatedBy, CreatedDate, IsDeleted) VALUES ('Default', 'System', GETUTCDATE(), 0);
                IF NOT EXISTS (SELECT 1 FROM Regions) INSERT INTO Regions (RegionName, CreatedBy, CreatedDate, IsDeleted) VALUES ('Default', 'System', GETUTCDATE(), 0);
                IF NOT EXISTS (SELECT 1 FROM StoreCategories) INSERT INTO StoreCategories (CategoryName, CategoryNameAr, CreatedBy, CreatedDate, IsDeleted) VALUES ('Default', 'Default', 'System', GETUTCDATE(), 0);
                IF NOT EXISTS (SELECT 1 FROM Stores) INSERT INTO Stores (StoreName, StoreId, StoreCategoryId, CreatedBy, CreatedDate, IsDeleted) VALUES ('Default Store', 1, (SELECT TOP 1 Id FROM StoreCategories), 'System', GETUTCDATE(), 0);

                -- Populate ItemCategories from ItemLists.Category
                IF COL_LENGTH('ItemLists', 'Category') IS NOT NULL
                BEGIN
                    INSERT INTO ItemCategories (ItemCategoryName, AccNo, AccName, CreatedBy, CreatedDate, IsDeleted)
                    SELECT DISTINCT Category, '0', 'Auto-Migrated', 'System', GETUTCDATE(), 0
                    FROM ItemLists WHERE Category IS NOT NULL AND Category != '' AND Category NOT IN (SELECT ItemCategoryName FROM ItemCategories);
                    UPDATE IL SET IL.ItemCategoryId = IC.Id FROM ItemLists IL JOIN ItemCategories IC ON IL.Category = IC.ItemCategoryName;
                END

                -- Populate Units from ItemLists.Unit
                IF COL_LENGTH('ItemLists', 'Unit') IS NOT NULL
                BEGIN
                    INSERT INTO Units (UnitName, CreatedBy, CreatedDate, IsDeleted)
                    SELECT DISTINCT Unit, 'System', GETUTCDATE(), 0
                    FROM ItemLists WHERE Unit IS NOT NULL AND Unit != '' AND Unit NOT IN (SELECT UnitName FROM Units);
                    UPDATE IL SET IL.UnitId = U.Id FROM ItemLists IL JOIN Units U ON IL.Unit = U.UnitName;
                END

                -- Populate ItemLists for ItemIds if they exist
                IF COL_LENGTH('ItemRegistries', 'ItemName') IS NOT NULL
                BEGIN
                    INSERT INTO ItemLists (ItemName, ItemCategoryId, UnitId, Sales, MinimumLevel, ItemOrder, CreatedBy, CreatedDate, IsDeleted)
                    SELECT DISTINCT ItemName, (SELECT TOP 1 Id FROM ItemCategories), (SELECT TOP 1 Id FROM Units), 1, 0, 0, 'System', GETUTCDATE(), 0
                    FROM ItemRegistries WHERE ItemName IS NOT NULL AND ItemName != '' AND ItemName NOT IN (SELECT ItemName FROM ItemLists);
                    UPDATE IR SET IR.ItemId = IL.Id FROM ItemRegistries IR JOIN ItemLists IL ON IR.ItemName = IL.ItemName;
                END

                -- Sync other tables
                UPDATE ItemLists SET ItemCategoryId = (SELECT TOP 1 Id FROM ItemCategories) WHERE ItemCategoryId = 0;
                UPDATE ItemLists SET UnitId = (SELECT TOP 1 Id FROM Units) WHERE UnitId = 0;
                UPDATE SupplierItems SET ItemCategoryId = (SELECT TOP 1 Id FROM ItemCategories) WHERE ItemCategoryId = 0;
                UPDATE SupplierItems SET ItemId = (SELECT TOP 1 Id FROM ItemLists) WHERE ItemId = 0;
                UPDATE ItemRegistries SET ClientTypeId = (SELECT TOP 1 Id FROM ClientTypes) WHERE ClientTypeId = 0;
                UPDATE ItemRegistries SET ItemId = (SELECT TOP 1 Id FROM ItemLists) WHERE ItemId = 0;
                UPDATE ItemRegistries SET RegionId = (SELECT TOP 1 Id FROM Regions) WHERE RegionId = 0;
                UPDATE ItemRegistries SET StoreId = (SELECT TOP 1 Id FROM Stores) WHERE StoreId = 0;
                UPDATE ClientPriceLists SET ItemCategoryId = (SELECT TOP 1 Id FROM ItemCategories) WHERE ItemCategoryId = 0;
                UPDATE ClientPriceLists SET ItemId = (SELECT TOP 1 Id FROM ItemLists) WHERE ItemId = 0;
            ");

            // Now safely drop the old columns
            migrationBuilder.DropColumn(name: "SupplierCountry", table: "Suppliers");
            migrationBuilder.DropColumn(name: "ItemCategory", table: "SupplierItems");
            migrationBuilder.DropColumn(name: "ItemName", table: "SupplierItems");
            migrationBuilder.DropColumn(name: "SupplierName", table: "SupplierItems");
            migrationBuilder.DropColumn(name: "ClientType", table: "ItemRegistries");
            migrationBuilder.DropColumn(name: "ItemCategory", table: "ItemRegistries");
            migrationBuilder.DropColumn(name: "ItemName", table: "ItemRegistries");
            migrationBuilder.DropColumn(name: "Region", table: "ItemRegistries");
            migrationBuilder.DropColumn(name: "Category", table: "ItemLists");
            migrationBuilder.DropColumn(name: "Unit", table: "ItemLists");
            migrationBuilder.DropColumn(name: "ItemCategory", table: "ClientPriceLists");
            migrationBuilder.DropColumn(name: "ItemName", table: "ClientPriceLists");

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
                name: "FK_SupplierItems_ItemLists_ItemId",
                table: "SupplierItems",
                column: "ItemId",
                principalTable: "ItemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_SupplierItems_ItemLists_ItemId",
                table: "SupplierItems");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AccNo",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CR",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_VATNo",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_SupplierItems_ItemCategoryId",
                table: "SupplierItems");

            migrationBuilder.DropIndex(
                name: "IX_SupplierItems_ItemId",
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
                name: "IX_ClientPriceLists_ItemCategoryId",
                table: "ClientPriceLists");

            migrationBuilder.DropIndex(
                name: "IX_ClientPriceLists_ItemId",
                table: "ClientPriceLists");

            migrationBuilder.DropColumn(
                name: "ItemCategoryId",
                table: "SupplierItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
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
                name: "ItemCategoryId",
                table: "ClientPriceLists");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ClientPriceLists",
                newName: "ItemSNo");

            migrationBuilder.AlterColumn<string>(
                name: "VATNo",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fax",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Suppliers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CR",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccNo",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCountry",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "SupplierItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "SupplierItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
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

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AccNo",
                table: "Suppliers",
                column: "AccNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CR",
                table: "Suppliers",
                column: "CR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_VATNo",
                table: "Suppliers",
                column: "VATNo",
                unique: true);
        }
    }
}
