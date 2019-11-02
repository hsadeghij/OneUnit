using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00038 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlan",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    DateReg = table.Column<string>(nullable: true),
                    ActivityId = table.Column<int>(nullable: true),
                    WorkTypeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlan_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "Tran",
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectPlan_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Tran",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectPlan_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Tran",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectPlan_WorkType_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalSchema: "Tran",
                        principalTable: "WorkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectActivity",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectPlanId = table.Column<int>(nullable: true),
                    TransitInfoId = table.Column<int>(nullable: true),
                    DateReg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectActivity_ProjectPlan_ProjectPlanId",
                        column: x => x.ProjectPlanId,
                        principalSchema: "Tran",
                        principalTable: "ProjectPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectActivity_TransitInfo_TransitInfoId",
                        column: x => x.TransitInfoId,
                        principalSchema: "Tran",
                        principalTable: "TransitInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivity_ProjectPlanId",
                schema: "Tran",
                table: "ProjectActivity",
                column: "ProjectPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivity_TransitInfoId",
                schema: "Tran",
                table: "ProjectActivity",
                column: "TransitInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlan_ActivityId",
                schema: "Tran",
                table: "ProjectPlan",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlan_PersonId",
                schema: "Tran",
                table: "ProjectPlan",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlan_ProjectId",
                schema: "Tran",
                table: "ProjectPlan",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlan_WorkTypeId",
                schema: "Tran",
                table: "ProjectPlan",
                column: "WorkTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectActivity",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "ProjectPlan",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "Activity",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Tran");
        }
    }
}
