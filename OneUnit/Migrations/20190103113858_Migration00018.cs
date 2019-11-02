using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeHour",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplingLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_SamplingLocation_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplingLocationId",
                principalSchema: "QC",
                principalTable: "SamplingLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_SamplingLocation_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "SamplingLocationId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "TimeHour",
                schema: "QC",
                table: "QualityDesign");
        }
    }
}
