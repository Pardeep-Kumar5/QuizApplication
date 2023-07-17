using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class AddStudentScoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateTable(
                name: "scoreTables",
                columns: table => new
                {
                    ScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    registerTableid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scoreTables", x => x.ScoreID);
                    table.ForeignKey(
                        name: "FK_scoreTables_RegisterTable_registerTableid",
                        column: x => x.registerTableid,
                        principalTable: "RegisterTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scoreTables_registerTableid",
                table: "scoreTables",
                column: "registerTableid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scoreTables");

            migrationBuilder.CreateTable(
                name: "participantTables",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TimeSpent = table.Column<int>(type: "int", nullable: false),
                    registerTableid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participantTables", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_participantTables_RegisterTable_registerTableid",
                        column: x => x.registerTableid,
                        principalTable: "RegisterTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_participantTables_registerTableid",
                table: "participantTables",
                column: "registerTableid");
        }
    }
}
