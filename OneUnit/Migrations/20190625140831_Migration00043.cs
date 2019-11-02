using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorkers_ProjectPlan_ProjectPlanId",
                table: "TraceWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorkers_TransitInfo_TransitInfoId",
                table: "TraceWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorkers_TransitTypes_TransitTypeId",
                table: "TraceWorkers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransitTypes",
                table: "TransitTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraceWorkers",
                table: "TraceWorkers");

            migrationBuilder.RenameTable(
                name: "TransitTypes",
                newName: "TransitType",
                newSchema: "Tran");

            migrationBuilder.RenameTable(
                name: "TraceWorkers",
                newName: "TraceWorker",
                newSchema: "Tran");

            migrationBuilder.RenameIndex(
                name: "IX_TraceWorkers_TransitTypeId",
                schema: "Tran",
                table: "TraceWorker",
                newName: "IX_TraceWorker_TransitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TraceWorkers_TransitInfoId",
                schema: "Tran",
                table: "TraceWorker",
                newName: "IX_TraceWorker_TransitInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_TraceWorkers_ProjectPlanId",
                schema: "Tran",
                table: "TraceWorker",
                newName: "IX_TraceWorker_ProjectPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransitType",
                schema: "Tran",
                table: "TransitType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraceWorker",
                schema: "Tran",
                table: "TraceWorker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorker_ProjectPlan_ProjectPlanId",
                schema: "Tran",
                table: "TraceWorker",
                column: "ProjectPlanId",
                principalSchema: "Tran",
                principalTable: "ProjectPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorker_TransitInfo_TransitInfoId",
                schema: "Tran",
                table: "TraceWorker",
                column: "TransitInfoId",
                principalSchema: "Tran",
                principalTable: "TransitInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorker_TransitType_TransitTypeId",
                schema: "Tran",
                table: "TraceWorker",
                column: "TransitTypeId",
                principalSchema: "Tran",
                principalTable: "TransitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorker_ProjectPlan_ProjectPlanId",
                schema: "Tran",
                table: "TraceWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorker_TransitInfo_TransitInfoId",
                schema: "Tran",
                table: "TraceWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_TraceWorker_TransitType_TransitTypeId",
                schema: "Tran",
                table: "TraceWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransitType",
                schema: "Tran",
                table: "TransitType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraceWorker",
                schema: "Tran",
                table: "TraceWorker");

            migrationBuilder.RenameTable(
                name: "TransitType",
                schema: "Tran",
                newName: "TransitTypes");

            migrationBuilder.RenameTable(
                name: "TraceWorker",
                schema: "Tran",
                newName: "TraceWorkers");

            migrationBuilder.RenameIndex(
                name: "IX_TraceWorker_TransitTypeId",
                table: "TraceWorkers",
                newName: "IX_TraceWorkers_TransitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TraceWorker_TransitInfoId",
                table: "TraceWorkers",
                newName: "IX_TraceWorkers_TransitInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_TraceWorker_ProjectPlanId",
                table: "TraceWorkers",
                newName: "IX_TraceWorkers_ProjectPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransitTypes",
                table: "TransitTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraceWorkers",
                table: "TraceWorkers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorkers_ProjectPlan_ProjectPlanId",
                table: "TraceWorkers",
                column: "ProjectPlanId",
                principalSchema: "Tran",
                principalTable: "ProjectPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorkers_TransitInfo_TransitInfoId",
                table: "TraceWorkers",
                column: "TransitInfoId",
                principalSchema: "Tran",
                principalTable: "TransitInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraceWorkers_TransitTypes_TransitTypeId",
                table: "TraceWorkers",
                column: "TransitTypeId",
                principalTable: "TransitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
