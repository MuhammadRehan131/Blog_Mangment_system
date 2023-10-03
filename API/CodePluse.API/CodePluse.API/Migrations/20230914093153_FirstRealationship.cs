using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePluse.API.Migrations
{
    /// <inheritdoc />
    public partial class FirstRealationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostCategory_Categories_CategoryId",
                table: "BlogPostCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BlogPostCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostCategory_CategoryId",
                table: "BlogPostCategory",
                newName: "IX_BlogPostCategory_CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostCategory_Categories_CategoriesId",
                table: "BlogPostCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostCategory_Categories_CategoriesId",
                table: "BlogPostCategory");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "BlogPostCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostCategory_CategoriesId",
                table: "BlogPostCategory",
                newName: "IX_BlogPostCategory_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostCategory_Categories_CategoryId",
                table: "BlogPostCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
