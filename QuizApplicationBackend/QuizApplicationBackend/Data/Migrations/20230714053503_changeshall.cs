using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class changeshall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_categories_CagetoryId",
                table: "questionTables");

            migrationBuilder.RenameColumn(
                name: "CagetoryId",
                table: "questionTables",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_questionTables_CagetoryId",
                table: "questionTables",
                newName: "IX_questionTables_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_questionTables_categories_CategoryId",
                table: "questionTables",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_categories_CategoryId",
                table: "questionTables");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "questionTables",
                newName: "CagetoryId");

            migrationBuilder.RenameIndex(
                name: "IX_questionTables_CategoryId",
                table: "questionTables",
                newName: "IX_questionTables_CagetoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_questionTables_categories_CagetoryId",
                table: "questionTables",
                column: "CagetoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
