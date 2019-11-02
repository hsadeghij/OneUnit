using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00055 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "QC",
                table: "PauseTime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PauseTime_CompanyId",
                schema: "QC",
                table: "PauseTime",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PauseTime_Company_CompanyId",
                schema: "QC",
                table: "PauseTime",
                column: "CompanyId",
                principalSchema: "QC",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PauseTime_Company_CompanyId",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropIndex(
                name: "IX_PauseTime_CompanyId",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "QC",
                table: "PauseTime");
        }
    }
}
