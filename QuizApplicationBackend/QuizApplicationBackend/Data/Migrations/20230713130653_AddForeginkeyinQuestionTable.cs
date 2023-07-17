using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class AddForeginkeyinQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_categories_categoryTableId",
                table: "questionTables");

            migrationBuilder.DropIndex(
                name: "IX_questionTables_categoryTableId",
                table: "questionTables");

            migrationBuilder.DropColumn(
                name: "categoryTableId",
                table: "questionTables");

            migrationBuilder.CreateIndex(
                name: "IX_questionTables_CagetoryId",
                table: "questionTables",
                column: "CagetoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_questionTables_categories_CagetoryId",
                table: "questionTables",
                column: "CagetoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_categories_CagetoryId",
                table: "questionTables");

            migrationBuilder.DropIndex(
                name: "IX_questionTables_CagetoryId",
                table: "questionTables");

            migrationBuilder.AddColumn<int>(
                name: "categoryTableId",
                table: "questionTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_questionTables_categoryTableId",
                table: "questionTables",
                column: "categoryTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_questionTables_categories_categoryTableId",
                table: "questionTables",
                column: "categoryTableId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
