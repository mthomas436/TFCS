using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCS.API.Migrations
{
    public partial class updatedsurveyquestinsclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "SurveyQuestions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Required",
                table: "SurveyQuestions");
        }
    }
}
