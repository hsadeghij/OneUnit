using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PauseTime_Hour_HourId1",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropIndex(
                name: "IX_PauseTime_HourId1",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropColumn(
                name: "HourId",
                schema: "QC",
                table: "PauseTime");

            migrationBuilder.DropColumn(
                name: "HourId1",
                schema: "QC",
                table: "PauseTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HourId",
                schema: "QC",
                table: "PauseTime",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "HourId1",
                schema: "QC",
                table: "PauseTime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PauseTime_HourId1",
                schema: "QC",
                table: "PauseTime",
                column: "HourId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PauseTime_Hour_HourId1",
                schema: "QC",
                table: "PauseTime",
                column: "HourId1",
                principalSchema: "QC",
                principalTable: "Hour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
