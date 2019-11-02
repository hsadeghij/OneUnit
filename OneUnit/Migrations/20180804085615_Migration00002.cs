using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_AspNetUsers_ControllerUserId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_AspNetUsers_SamplerId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_AspNetUsers_TesterId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_ControllerUserId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_SamplerId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_TesterId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "ControllerUserId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "SamplerId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "TesterId",
                schema: "QC",
                table: "QualityDesign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControllerUserId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SamplerId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TesterId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_ControllerUserId",
                schema: "QC",
                table: "QualityDesign",
                column: "ControllerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_SamplerId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplerId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_TesterId",
                schema: "QC",
                table: "QualityDesign",
                column: "TesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_AspNetUsers_ControllerUserId",
                schema: "QC",
                table: "QualityDesign",
                column: "ControllerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_AspNetUsers_SamplerId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_AspNetUsers_TesterId",
                schema: "QC",
                table: "QualityDesign",
                column: "TesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
