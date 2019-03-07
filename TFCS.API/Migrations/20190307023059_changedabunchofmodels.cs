using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCS.API.Migrations
{
    public partial class changedabunchofmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleMakes");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Vin",
                table: "Vehicles",
                newName: "VIN");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Vehicles",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "Vehicles",
                newName: "Vin");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    MakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.ModelId);
                });
        }
    }
}
