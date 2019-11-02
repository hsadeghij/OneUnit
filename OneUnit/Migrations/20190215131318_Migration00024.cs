using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessName_HasT_HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HasT",
                table: "HasT");

            migrationBuilder.RenameTable(
                name: "HasT",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "HasT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HasT",
                table: "HasT",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessName_HasT_HasTId1",
                schema: "QC",
                table: "ProcessName",
                column: "HasTId1",
                principalTable: "HasT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
