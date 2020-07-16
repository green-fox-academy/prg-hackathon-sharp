using Microsoft.EntityFrameworkCore.Migrations;

namespace programmersGuide.Migrations
{
    public partial class ChangeToQuizEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackEnd",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "FrontEnd",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "FullStack",
                table: "Quiz");

            migrationBuilder.AddColumn<long>(
                name: "ResultCount",
                table: "Quiz",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ResultType",
                table: "Quiz",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultCount",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "ResultType",
                table: "Quiz");

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
