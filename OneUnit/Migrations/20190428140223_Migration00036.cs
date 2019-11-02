using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00036 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_CurrentState_CurrentStateId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CurrentStateId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CurrentStateId",
                schema: "Tran",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStateId",
                schema: "Tran",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CurrentStateId",
                schema: "Tran",
                table: "Person",
                column: "CurrentStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CurrentState_CurrentStateId",
                schema: "Tran",
                table: "Person",
                column: "CurrentStateId",
                principalSchema: "Tran",
                principalTable: "CurrentState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
