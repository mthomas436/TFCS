using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCS.API.Migrations
{
    public partial class updatedsurveyquestionsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyTypeId",
                table: "SurveyQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyTypeId",
                table: "SurveyQuestions");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
