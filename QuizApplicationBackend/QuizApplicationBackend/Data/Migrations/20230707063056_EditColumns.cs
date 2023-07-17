using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class EditColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participantTables_RegisterTable_CreatedByUserid",
                table: "participantTables");

            migrationBuilder.DropForeignKey(
                name: "FK_questionTables_participantTables_ParticipantTableParticipatntID",
                table: "questionTables");

            migrationBuilder.DropIndex(
                name: "IX_questionTables_ParticipantTableParticipatntID",
                table: "questionTables");

            migrationBuilder.DropIndex(
                name: "IX_participantTables_CreatedByUserid",
                table: "participantTables");

            migrationBuilder.DropColumn(
                name: "ParticipantTableParticipatntID",
                table: "questionTables");

            migrationBuilder.DropColumn(
                name: "CreatedByUserid",
                table: "participantTables");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "participantTables");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "participantTables");

            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "participantTables");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "participantTables");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "participantTables",
                newName: "TimeSpent");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "participantTables",
                newName: "Score");

            migrationBuilder.AlterColumn<int>(
                name: "Answer",
                table: "questionTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "participantTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "participantTables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "participantTables");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "participantTables");

            migrationBuilder.RenameColumn(
                name: "TimeSpent",
                table: "participantTables",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "participantTables",
                newName: "CreatedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "questionTables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantTableParticipatntID",
                table: "questionTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserid",
                table: "participantTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "participantTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "participantTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "participantTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "participantTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_questionTables_ParticipantTableParticipatntID",
                table: "questionTables",
                column: "ParticipantTableParticipatntID");

            migrationBuilder.CreateIndex(
                name: "IX_participantTables_CreatedByUserid",
                table: "participantTables",
                column: "CreatedByUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_participantTables_RegisterTable_CreatedByUserid",
                table: "participantTables",
                column: "CreatedByUserid",
                principalTable: "RegisterTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_questionTables_participantTables_ParticipantTableParticipatntID",
                table: "questionTables",
                column: "ParticipantTableParticipatntID",
                principalTable: "participantTables",
                principalColumn: "ParticipatntID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
