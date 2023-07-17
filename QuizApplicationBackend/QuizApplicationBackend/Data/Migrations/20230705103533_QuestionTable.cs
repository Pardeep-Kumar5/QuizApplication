using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class QuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questionTables",
                columns: table => new
                {
                    Question_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionTables", x => x.Question_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questionTables");
        }
    }
}
