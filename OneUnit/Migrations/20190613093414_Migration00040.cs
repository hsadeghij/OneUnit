using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00040 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectMember",
                schema: "Tran");

            migrationBuilder.AddColumn<string>(
                name: "WorkerList",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkerListCodes",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerList",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.DropColumn(
                name: "WorkerListCodes",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.CreateTable(
                name: "ProjectMember",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    ProjectPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectMember_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Tran",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectMember_ProjectPlan_ProjectPlanId",
                        column: x => x.ProjectPlanId,
                        principalSchema: "Tran",
                        principalTable: "ProjectPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_PersonId",
                schema: "Tran",
                table: "ProjectMember",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_ProjectPlanId",
                schema: "Tran",
                table: "ProjectMember",
                column: "ProjectPlanId");
        }
    }
}
