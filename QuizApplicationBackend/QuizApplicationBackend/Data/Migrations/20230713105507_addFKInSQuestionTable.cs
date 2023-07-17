using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class addFKInSQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CagetoryId",
                table: "questionTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_categories_categoryTableId",
                table: "questionTables");

            migrationBuilder.DropIndex(
                name: "IX_questionTables_categoryTableId",
                table: "questionTables");

            migrationBuilder.DropColumn(
                name: "CagetoryId",
                table: "questionTables");

            migrationBuilder.DropColumn(
                name: "categoryTableId",
                table: "questionTables");
        }
    }
}
