using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00046 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                schema: "Tran",
                table: "TraceWorker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TraceWorker_PostId",
                schema: "Tran",
                table: "TraceWorker",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorker_Post_PostId",
                schema: "Tran",
                table: "TraceWorker",
                column: "PostId",
                principalSchema: "Tran",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorker_Post_PostId",
                schema: "Tran",
                table: "TraceWorker");

            migrationBuilder.DropIndex(
                name: "IX_TraceWorker_PostId",
                schema: "Tran",
                table: "TraceWorker");

            migrationBuilder.DropColumn(
                name: "PostId",
                schema: "Tran",
                table: "TraceWorker");
        }
    }
}
