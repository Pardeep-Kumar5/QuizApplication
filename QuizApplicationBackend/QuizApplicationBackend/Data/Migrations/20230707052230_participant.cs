using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class participant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantTableParticipatntID",
                table: "questionTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "participantTables",
                columns: table => new
                {
                    ParticipatntID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participantTables", x => x.ParticipatntID);
                    table.ForeignKey(
                        name: "FK_participantTables_RegisterTable_CreatedByUserid",
                        column: x => x.CreatedByUserid,
                        principalTable: "RegisterTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questionTables_ParticipantTableParticipatntID",
                table: "questionTables",
                column: "ParticipantTableParticipatntID");

            migrationBuilder.CreateIndex(
                name: "IX_participantTables_CreatedByUserid",
                table: "participantTables",
                column: "CreatedByUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_questionTables_participantTables_ParticipantTableParticipatntID",
                table: "questionTables",
                column: "ParticipantTableParticipatntID",
                principalTable: "participantTables",
                principalColumn: "ParticipatntID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_participantTables_ParticipantTableParticipatntID",
                table: "questionTables");

            migrationBuilder.DropTable(
                name: "participantTables");

            migrationBuilder.DropIndex(
                name: "IX_questionTables_ParticipantTableParticipatntID",
                table: "questionTables");

            migrationBuilder.DropColumn(
                name: "ParticipantTableParticipatntID",
                table: "questionTables");
        }
    }
}
