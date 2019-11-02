using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessName_HasTs_HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HasTs",
                table: "HasTs");

            migrationBuilder.RenameTable(
                name: "HasTs",
                newName: "HasT",
                newSchema: "QC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HasT",
                schema: "QC",
                table: "HasT",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessName_HasT_HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HasT",
                schema: "QC",
                table: "HasT");

            migrationBuilder.RenameTable(
                name: "HasT",
                schema: "QC",
                newName: "HasTs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HasTs",
                table: "HasTs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessName_HasTs_HasTId1",
                schema: "QC",
                table: "ProcessName",
                column: "HasTId1",
                principalTable: "HasTs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
