using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00041 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraceWorkers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransitInfoId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    DateReg = table.Column<string>(nullable: true),
                    TimeReg = table.Column<string>(nullable: true),
                    TransitTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraceWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraceWorkers_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Tran",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraceWorkers_TransitInfo_TransitInfoId",
                        column: x => x.TransitInfoId,
                        principalSchema: "Tran",
                        principalTable: "TransitInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraceWorkers_TransitTypes_TransitTypeId",
                        column: x => x.TransitTypeId,
                        principalTable: "TransitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraceWorkers_ProjectId",
                table: "TraceWorkers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TraceWorkers_TransitInfoId",
                table: "TraceWorkers",
                column: "TransitInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TraceWorkers_TransitTypeId",
                table: "TraceWorkers",
                column: "TransitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraceWorkers");

            migrationBuilder.DropTable(
                name: "TransitTypes");
        }
    }
}
