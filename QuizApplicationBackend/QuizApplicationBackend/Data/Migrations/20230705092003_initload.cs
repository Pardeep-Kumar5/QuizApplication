using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class initload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterTable",
                columns: table => new
                {
                    Register_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Register_Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Register_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Register_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Register_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Register_Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTable", x => x.Register_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterTable");
        }
    }
}
