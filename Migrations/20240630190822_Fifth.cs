using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "ProductCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "CategoryVariations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryId",
                table: "ProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVariations_ProductCategoryId",
                table: "CategoryVariations",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVariations_ProductCategories_ProductCategoryId",
                table: "CategoryVariations",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ProductCategoryId",
                table: "ProductCategories",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVariations_ProductCategories_ProductCategoryId",
                table: "CategoryVariations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_CategoryVariations_ProductCategoryId",
                table: "CategoryVariations");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "CategoryVariations");
        }
    }
}
