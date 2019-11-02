using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_ColumnNumber_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Production_ProductionId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_SamplingLocation_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Tank_TankId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_ProductionId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_TankId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "ColumnNumberId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "SamplingLocationId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "TankId",
                schema: "QC",
                table: "QualityDesign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                column: "ColumnNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_ProductionId",
                schema: "QC",
                table: "QualityDesign",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_StorageId",
                schema: "QC",
                table: "QualityDesign",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_TankId",
                schema: "QC",
                table: "QualityDesign",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_ColumnNumber_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                column: "ColumnNumberId",
                principalSchema: "QC",
                principalTable: "ColumnNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Production_ProductionId",
                schema: "QC",
                table: "QualityDesign",
                column: "ProductionId",
                principalSchema: "QC",
                principalTable: "Production",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_SamplingLocation_SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplingLocationId",
                principalSchema: "QC",
                principalTable: "SamplingLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign",
                column: "StorageId",
                principalSchema: "QC",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Tank_TankId",
                schema: "QC",
                table: "QualityDesign",
                column: "TankId",
                principalSchema: "QC",
                principalTable: "Tank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
