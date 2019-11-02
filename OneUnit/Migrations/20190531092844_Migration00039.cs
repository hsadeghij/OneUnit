using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00039 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlan_Activity_ActivityId",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.DropTable(
                name: "Activity",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "ProjectActivity",
                schema: "Tran");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlan_ActivityId",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachment",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<byte[]>(nullable: true),
                    ProjectPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_ProjectPlan_ProjectPlanId",
                        column: x => x.ProjectPlanId,
                        principalSchema: "Tran",
                        principalTable: "ProjectPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMember",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectPlanId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
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
                name: "IX_Attachment_ProjectPlanId",
                schema: "Tran",
                table: "Attachment",
                column: "ProjectPlanId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "ProjectMember",
                schema: "Tran");

            migrationBuilder.DropColumn(
                name: "Activity",
                schema: "Tran",
                table: "ProjectPlan");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                schema: "Tran",
                table: "ProjectPlan",
                nullable: true);

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
                name: "ProjectActivity",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateReg = table.Column<string>(nullable: true),
                    ProjectPlanId = table.Column<int>(nullable: true),
                    TransitInfoId = table.Column<int>(nullable: true)
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
                name: "IX_ProjectPlan_ActivityId",
                schema: "Tran",
                table: "ProjectPlan",
                column: "ActivityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlan_Activity_ActivityId",
                schema: "Tran",
                table: "ProjectPlan",
                column: "ActivityId",
                principalSchema: "Tran",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
