using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class AddStudentScoreTablaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scoreTables_RegisterTable_registerTableid",
                table: "scoreTables");

            migrationBuilder.DropIndex(
                name: "IX_scoreTables_registerTableid",
                table: "scoreTables");

            migrationBuilder.DropColumn(
                name: "registerTableid",
                table: "scoreTables");

            migrationBuilder.CreateIndex(
                name: "IX_scoreTables_RegisterId",
                table: "scoreTables",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_scoreTables_RegisterTable_RegisterId",
                table: "scoreTables",
                column: "RegisterId",
                principalTable: "RegisterTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scoreTables_RegisterTable_RegisterId",
                table: "scoreTables");

            migrationBuilder.DropIndex(
                name: "IX_scoreTables_RegisterId",
                table: "scoreTables");

            migrationBuilder.AddColumn<int>(
                name: "registerTableid",
                table: "scoreTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_scoreTables_registerTableid",
                table: "scoreTables",
                column: "registerTableid");

            migrationBuilder.AddForeignKey(
                name: "FK_scoreTables_RegisterTable_registerTableid",
                table: "scoreTables",
                column: "registerTableid",
                principalTable: "RegisterTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
