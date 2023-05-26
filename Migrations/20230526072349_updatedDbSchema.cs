using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAppBE.Migrations
{
    /// <inheritdoc />
    public partial class updatedDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredient_Ingredients_IngredientId",
                table: "ItemIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredient_Items_ItemsItemId",
                table: "ItemIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemIngredient",
                table: "ItemIngredient");

            migrationBuilder.RenameTable(
                name: "ItemIngredient",
                newName: "ItemIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_ItemIngredient_ItemsItemId",
                table: "ItemIngredients",
                newName: "IX_ItemIngredients_ItemsItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients",
                columns: new[] { "IngredientId", "ItemsItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredients_Ingredients_IngredientId",
                table: "ItemIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredients_Items_ItemsItemId",
                table: "ItemIngredients",
                column: "ItemsItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredients_Ingredients_IngredientId",
                table: "ItemIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredients_Items_ItemsItemId",
                table: "ItemIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients");

            migrationBuilder.RenameTable(
                name: "ItemIngredients",
                newName: "ItemIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_ItemIngredients_ItemsItemId",
                table: "ItemIngredient",
                newName: "IX_ItemIngredient_ItemsItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemIngredient",
                table: "ItemIngredient",
                columns: new[] { "IngredientId", "ItemsItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredient_Ingredients_IngredientId",
                table: "ItemIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredient_Items_ItemsItemId",
                table: "ItemIngredient",
                column: "ItemsItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
