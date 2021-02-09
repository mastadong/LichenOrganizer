using Microsoft.EntityFrameworkCore.Migrations;

namespace LichenOrganizer.DataAccess.Migrations
{
    public partial class AddCommentFieldToLichenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Lichens",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Lichens");
        }
    }
}
