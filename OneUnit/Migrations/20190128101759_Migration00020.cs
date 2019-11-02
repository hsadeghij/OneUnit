using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "QC",
                table: "SamplingLocation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SamplingLocation_CompanyId",
                schema: "QC",
                table: "SamplingLocation",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SamplingLocation_Company_CompanyId",
                schema: "QC",
                table: "SamplingLocation",
                column: "CompanyId",
                principalSchema: "QC",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamplingLocation_Company_CompanyId",
                schema: "QC",
                table: "SamplingLocation");

            migrationBuilder.DropIndex(
                name: "IX_SamplingLocation_CompanyId",
                schema: "QC",
                table: "SamplingLocation");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "QC",
                table: "SamplingLocation");
        }
    }
}
