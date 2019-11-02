using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00048 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                schema: "QC",
                table: "Company",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectPlanInCurrentDateViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WorkTypeName = table.Column<string>(nullable: true),
                    SarparastList = table.Column<string>(nullable: true),
                    OstadKarList = table.Column<string>(nullable: true),
                    WorkerList = table.Column<string>(nullable: true),
                    DateReg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlanInCurrentDateViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_SiteId",
                schema: "QC",
                table: "Company",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Site_SiteId",
                schema: "QC",
                table: "Company",
                column: "SiteId",
                principalSchema: "QC",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Site_SiteId",
                schema: "QC",
                table: "Company");

            migrationBuilder.DropTable(
                name: "ProjectPlanInCurrentDateViewModels");

            migrationBuilder.DropTable(
                name: "Site",
                schema: "QC");

            migrationBuilder.DropIndex(
                name: "IX_Company_SiteId",
                schema: "QC",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SiteId",
                schema: "QC",
                table: "Company");
        }
    }
}
