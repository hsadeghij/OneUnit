using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasStorage",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.AddColumn<int>(
                name: "HasTId",
                schema: "QC",
                table: "ProcessName",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "HasTId1",
                schema: "QC",
                table: "ProcessName",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HasT",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasT", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "HasT");

            migrationBuilder.DropIndex(
                name: "IX_ProcessName_HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropColumn(
                name: "HasTId",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropColumn(
                name: "HasTId1",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.AddColumn<bool>(
                name: "HasStorage",
                schema: "QC",
                table: "ProcessName",
                nullable: true);
        }
    }
}
