using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAppBE.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDBSchemaForOrdersToStoreQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ComandaItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ComandaItem");
        }
    }
}
