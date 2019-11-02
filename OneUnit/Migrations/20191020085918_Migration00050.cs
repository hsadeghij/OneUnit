using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00050 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TypeOfCorn",
                newName: "TypeOfCorn",
                newSchema: "QC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TypeOfCorn",
                schema: "QC",
                newName: "TypeOfCorn");
        }
    }
}
