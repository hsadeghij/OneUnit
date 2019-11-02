using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00029 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "QC",
                table: "ControlParameter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_CompanyId",
                schema: "QC",
                table: "ControlParameter",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_Company_CompanyId",
                schema: "QC",
                table: "ControlParameter",
                column: "CompanyId",
                principalSchema: "QC",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_Company_CompanyId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_CompanyId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "QC",
                table: "ControlParameter");
        }
    }
}
