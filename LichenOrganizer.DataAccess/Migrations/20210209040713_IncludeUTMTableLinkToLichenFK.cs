using Microsoft.EntityFrameworkCore.Migrations;

namespace LichenOrganizer.DataAccess.Migrations
{
    public partial class IncludeUTMTableLinkToLichenFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UTMEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eastings = table.Column<double>(type: "float", nullable: false),
                    Northings = table.Column<double>(type: "float", nullable: false),
                    LichenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UTMEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UTMEntries_Lichens_LichenId",
                        column: x => x.LichenId,
                        principalTable: "Lichens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UTMEntries_LichenId",
                table: "UTMEntries",
                column: "LichenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UTMEntries");
        }
    }
}
