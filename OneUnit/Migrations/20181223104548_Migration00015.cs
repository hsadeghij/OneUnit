using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmationId",
                schema: "QC",
                table: "QParameterStatus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QParameterStatus_ConfirmationId",
                schema: "QC",
                table: "QParameterStatus",
                column: "ConfirmationId");

            migrationBuilder.AddForeignKey(
                name: "FK_QParameterStatus_Confirmation_ConfirmationId",
                schema: "QC",
                table: "QParameterStatus",
                column: "ConfirmationId",
                principalSchema: "QC",
                principalTable: "Confirmation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QParameterStatus_Confirmation_ConfirmationId",
                schema: "QC",
                table: "QParameterStatus");

            migrationBuilder.DropIndex(
                name: "IX_QParameterStatus_ConfirmationId",
                schema: "QC",
                table: "QParameterStatus");

            migrationBuilder.DropColumn(
                name: "ConfirmationId",
                schema: "QC",
                table: "QParameterStatus");
        }
    }
}
