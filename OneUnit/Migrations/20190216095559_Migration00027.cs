using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00027 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_StorageId",
                schema: "QC",
                table: "QualityDesign",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign",
                column: "StorageId",
                principalSchema: "QC",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "StorageId",
                schema: "QC",
                table: "QualityDesign");
        }
    }
}
