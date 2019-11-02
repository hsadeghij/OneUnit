using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_CompanyId",
                schema: "QC",
                table: "QualityDesign",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Company_CompanyId",
                schema: "QC",
                table: "QualityDesign",
                column: "CompanyId",
                principalSchema: "QC",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Company_CompanyId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_CompanyId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "QC",
                table: "QualityDesign");
        }
    }
}
