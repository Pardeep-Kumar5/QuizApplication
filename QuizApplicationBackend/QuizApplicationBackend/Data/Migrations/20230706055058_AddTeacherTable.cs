using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class AddTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teacherTable",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teacher_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teacher_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teacher_Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherTable", x => x.Teacher_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacherTable");
        }
    }
}
