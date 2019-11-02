using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessName_HasT_HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropIndex(
                name: "IX_ProcessName_HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropColumn(
                name: "HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.AlterColumn<byte>(
                name: "HasTId",
                schema: "QC",
                table: "ProcessName",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ProcessName_HasTId",
                schema: "QC",
                table: "ProcessName",
                column: "HasTId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessName_HasT_HasTId",
                schema: "QC",
                table: "ProcessName",
                column: "HasTId",
                principalSchema: "QC",
                principalTable: "HasT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessName_HasT_HasTId",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropIndex(
                name: "IX_ProcessName_HasTId",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.AlterColumn<int>(
                name: "HasTId",
                schema: "QC",
                table: "ProcessName",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "HasTId1",
                schema: "QC",
                table: "ProcessName",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "QC",
                table: "ProcessName",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessName_HasTId1",
                schema: "QC",
                table: "ProcessName",
                column: "HasTId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessName_HasT_HasTId1",
                schema: "QC",
                table: "ProcessName",
                column: "HasTId1",
                principalSchema: "QC",
                principalTable: "HasT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
