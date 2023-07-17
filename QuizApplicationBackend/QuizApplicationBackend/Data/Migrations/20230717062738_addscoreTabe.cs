using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class addscoreTabe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentScoreTable",
                columns: table => new
                {
                    ScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TimeSpent = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentScoreTable", x => x.ScoreID);
                    table.ForeignKey(
                        name: "FK_StudentScoreTable_categories_CategoryTableId",
                        column: x => x.CategoryTableId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentScoreTable_RegisterTable_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "RegisterTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreTable_CategoryTableId",
                table: "StudentScoreTable",
                column: "CategoryTableId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreTable_RegisterId",
                table: "StudentScoreTable",
                column: "RegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentScoreTable");
        }
    }
}
