using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00054 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "HourId",
                schema: "QC",
                table: "PauseTime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PauseTime_HourId",
                schema: "QC",
                table: "PauseTime",
                column: "HourId");

            migrationBuilder.AddForeignKey(
                name: "FK_PauseTime_Hour_HourId",
                schema: "QC",
                table: "PauseTime",
                column: "HourId",
                principalSchema: "QC",
                principalTable: "Hour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PauseTime_Hour_HourId",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropIndex(
                name: "IX_PauseTime_HourId",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropColumn(
                name: "HourId",
                schema: "QC",
                table: "PauseTime");
        }
    }
}
