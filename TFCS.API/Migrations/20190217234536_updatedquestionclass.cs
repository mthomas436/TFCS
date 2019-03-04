using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCS.API.Migrations
{
    public partial class updatedquestionclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "SurveyQuestions",
                type: "VARCHAR(25)",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "SurveyQuestions");
        }
    }
}
