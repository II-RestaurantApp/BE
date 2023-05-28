using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAppBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchemaForOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandaItem_Comenzi_ComandaId",
                table: "ComandaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandaItem_Items_ItemItemId",
                table: "ComandaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComandaItem",
                table: "ComandaItem");

            migrationBuilder.RenameTable(
                name: "ComandaItem",
                newName: "ComandaItems");

            migrationBuilder.RenameIndex(
                name: "IX_ComandaItem_ItemItemId",
                table: "ComandaItems",
                newName: "IX_ComandaItems_ItemItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComandaItems",
                table: "ComandaItems",
                columns: new[] { "ComandaId", "ItemItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaItems_Comenzi_ComandaId",
                table: "ComandaItems",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaItems_Items_ItemItemId",
                table: "ComandaItems",
                column: "ItemItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandaItems_Comenzi_ComandaId",
                table: "ComandaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandaItems_Items_ItemItemId",
                table: "ComandaItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComandaItems",
                table: "ComandaItems");

            migrationBuilder.RenameTable(
                name: "ComandaItems",
                newName: "ComandaItem");

            migrationBuilder.RenameIndex(
                name: "IX_ComandaItems_ItemItemId",
                table: "ComandaItem",
                newName: "IX_ComandaItem_ItemItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComandaItem",
                table: "ComandaItem",
                columns: new[] { "ComandaId", "ItemItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaItem_Comenzi_ComandaId",
                table: "ComandaItem",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaItem_Items_ItemItemId",
                table: "ComandaItem",
                column: "ItemItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
