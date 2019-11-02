using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00033 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                schema: "Tran",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "CurrentStateId",
                schema: "Tran",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrentState",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentState", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_CurrentState_CurrentStateId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.DropTable(
                name: "CurrentState",
                schema: "Tran");

            migrationBuilder.DropIndex(
                name: "IX_Person_CurrentStateId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CurrentStateId",
                schema: "Tran",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentState",
                schema: "Tran",
                table: "Person",
                nullable: false,
                defaultValue: false);
        }
    }
}
