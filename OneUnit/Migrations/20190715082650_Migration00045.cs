using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00045 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OstadKarCodes",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OstadKarList",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SarparastCodes",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SarparastList",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OstadKarCodes",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.DropColumn(
                name: "OstadKarList",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.DropColumn(
                name: "SarparastCodes",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.DropColumn(
                name: "SarparastList",
                schema: "Tran",
                table: "ProjectPlan");
        }
    }
}
