using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApplicationBackend.Migrations
{
    public partial class ChagneProprtyRegisterTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Register_Role",
                table: "RegisterTable",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Register_Password",
                table: "RegisterTable",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Register_Name",
                table: "RegisterTable",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Register_Email",
                table: "RegisterTable",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Register_Address",
                table: "RegisterTable",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Register_Id",
                table: "RegisterTable",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "RegisterTable",
                newName: "Register_Role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "RegisterTable",
                newName: "Register_Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RegisterTable",
                newName: "Register_Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "RegisterTable",
                newName: "Register_Email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "RegisterTable",
                newName: "Register_Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RegisterTable",
                newName: "Register_Id");
        }
    }
}
