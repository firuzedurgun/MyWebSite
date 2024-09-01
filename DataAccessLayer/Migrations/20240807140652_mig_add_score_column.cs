using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_score_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Blogs_Categories_CategoryID",
            //    table: "Blogs");

            //migrationBuilder.RenameColumn(
            //    name: "CategoryID",
            //    table: "Blogs",
            //    newName: "CategoryId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Blogs_CategoryID",
            //    table: "Blogs",
            //    newName: "IX_Blogs_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //    migrationBuilder.AddForeignKey(
            //        name: "FK_Blogs_Categories_CategoryId",
            //        table: "Blogs",
            //        column: "CategoryId",
            //        principalTable: "Categories",
            //        principalColumn: "CategoryId",
            //        onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Blogs_Categories_CategoryId",
            //    table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Comments");

            //migrationBuilder.RenameColumn(
            //    name: "CategoryId",
            //    table: "Blogs",
            //    newName: "CategoryID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Blogs_CategoryId",
            //    table: "Blogs",
            //    newName: "IX_Blogs_CategoryID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Blogs_Categories_CategoryID",
            //    table: "Blogs",
            //    column: "CategoryID",
            //    principalTable: "Categories",
            //    principalColumn: "CategoryId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
