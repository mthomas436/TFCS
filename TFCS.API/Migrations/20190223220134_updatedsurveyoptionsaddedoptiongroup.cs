using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCS.API.Migrations
{
    public partial class updatedsurveyoptionsaddedoptiongroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionGroup",
                table: "SurveyOptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionGroup",
                table: "SurveyOptions");
        }
    }
}
