using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentScoreTable_categories_CategoryTableId",
                table: "StudentScoreTable");

            migrationBuilder.DropIndex(
                name: "IX_StudentScoreTable_CategoryTableId",
                table: "StudentScoreTable");

            migrationBuilder.DropColumn(
                name: "CategoryTableId",
                table: "StudentScoreTable");

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreTable_CategoryId",
                table: "StudentScoreTable",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentScoreTable_categories_CategoryId",
                table: "StudentScoreTable",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentScoreTable_categories_CategoryId",
                table: "StudentScoreTable");

            migrationBuilder.DropIndex(
                name: "IX_StudentScoreTable_CategoryId",
                table: "StudentScoreTable");

            migrationBuilder.AddColumn<int>(
                name: "CategoryTableId",
                table: "StudentScoreTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreTable_CategoryTableId",
                table: "StudentScoreTable",
                column: "CategoryTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentScoreTable_categories_CategoryTableId",
                table: "StudentScoreTable",
                column: "CategoryTableId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
