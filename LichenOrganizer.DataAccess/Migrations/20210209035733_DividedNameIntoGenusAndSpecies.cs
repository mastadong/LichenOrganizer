using Microsoft.EntityFrameworkCore.Migrations;

namespace LichenOrganizer.DataAccess.Migrations
{
    public partial class DividedNameIntoGenusAndSpecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lichens",
                newName: "Species");

            migrationBuilder.AlterColumn<int>(
                name: "Elevation",
                table: "Lichens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Genus",
                table: "Lichens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genus",
                table: "Lichens");

            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Lichens",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Elevation",
                table: "Lichens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
