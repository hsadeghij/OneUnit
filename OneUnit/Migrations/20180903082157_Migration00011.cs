using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_QParameterStatus_QParameterStatusId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.AlterColumn<int>(
                name: "QParameterStatusId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_QParameterStatus_QParameterStatusId",
                schema: "QC",
                table: "QualityDesign",
                column: "QParameterStatusId",
                principalSchema: "QC",
                principalTable: "QParameterStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_QParameterStatus_QParameterStatusId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.AlterColumn<int>(
                name: "QParameterStatusId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_QParameterStatus_QParameterStatusId",
                schema: "QC",
                table: "QualityDesign",
                column: "QParameterStatusId",
                principalSchema: "QC",
                principalTable: "QParameterStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
