using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessNameId",
                schema: "QC",
                table: "SamplingLocation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SamplingLocation_ProcessNameId",
                schema: "QC",
                table: "SamplingLocation",
                column: "ProcessNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_SamplingLocation_ProcessName_ProcessNameId",
                schema: "QC",
                table: "SamplingLocation",
                column: "ProcessNameId",
                principalSchema: "QC",
                principalTable: "ProcessName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamplingLocation_ProcessName_ProcessNameId",
                schema: "QC",
                table: "SamplingLocation");

            migrationBuilder.DropIndex(
                name: "IX_SamplingLocation_ProcessNameId",
                schema: "QC",
                table: "SamplingLocation");

            migrationBuilder.DropColumn(
                name: "ProcessNameId",
                schema: "QC",
                table: "SamplingLocation");
        }
    }
}
