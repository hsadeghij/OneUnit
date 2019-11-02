using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00034 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_WorkType_WorkTypeId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_WorkTypeId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                schema: "Tran",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkTypeId",
                schema: "Tran",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_WorkTypeId",
                schema: "Tran",
                table: "Person",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_WorkType_WorkTypeId",
                schema: "Tran",
                table: "Person",
                column: "WorkTypeId",
                principalSchema: "Tran",
                principalTable: "WorkType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
