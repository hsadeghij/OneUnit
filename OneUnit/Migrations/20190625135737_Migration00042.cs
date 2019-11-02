using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00042 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorkers_Project_ProjectId",
                table: "TraceWorkers");

            migrationBuilder.DropIndex(
                name: "IX_TraceWorkers_ProjectId",
                table: "TraceWorkers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TraceWorkers");

            migrationBuilder.AddColumn<int>(
                name: "ProjectPlanId",
                table: "TraceWorkers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TraceWorkers_ProjectPlanId",
                table: "TraceWorkers",
                column: "ProjectPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorkers_ProjectPlan_ProjectPlanId",
                table: "TraceWorkers",
                column: "ProjectPlanId",
                principalSchema: "Tran",
                principalTable: "ProjectPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorkers_ProjectPlan_ProjectPlanId",
                table: "TraceWorkers");

            migrationBuilder.DropIndex(
                name: "IX_TraceWorkers_ProjectPlanId",
                table: "TraceWorkers");

            migrationBuilder.DropColumn(
                name: "ProjectPlanId",
                table: "TraceWorkers");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TraceWorkers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TraceWorkers_ProjectId",
                table: "TraceWorkers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorkers_Project_ProjectId",
                table: "TraceWorkers",
                column: "ProjectId",
                principalSchema: "Tran",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
