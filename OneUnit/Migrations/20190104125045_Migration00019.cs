using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValueLimit",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValueLimit",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
