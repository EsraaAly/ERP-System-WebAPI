using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientTypeToForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientType",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientTypeId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId",
                principalTable: "ClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientTypeId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientType",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
