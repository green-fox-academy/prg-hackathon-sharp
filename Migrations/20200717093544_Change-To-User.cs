using Microsoft.EntityFrameworkCore.Migrations;

namespace programmersGuide.Migrations
{
    public partial class ChangeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BackEnd",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "FrontEnd",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "FullStack",
                table: "Quiz");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingPath",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingPath",
                table: "Quiz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultCount",
                table: "Quiz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingPath",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QuizAnswers",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgrammingPath",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProgrammingPath",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "ResultCount",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "ProgrammingPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "QuizAnswers",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackEnd",
                table: "Quiz",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontEnd",
                table: "Quiz",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FullStack",
                table: "Quiz",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
