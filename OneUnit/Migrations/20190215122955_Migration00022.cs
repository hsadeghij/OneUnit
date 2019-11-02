using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasStorage",
                schema: "QC",
                table: "ProcessName",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "QC",
                table: "ProcessName",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasStorage",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "QC",
                table: "ProcessName");
        }
    }
}
