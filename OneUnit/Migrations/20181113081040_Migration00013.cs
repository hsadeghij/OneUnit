using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "QC",
                table: "ProcessName",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessName_CompanyId",
                schema: "QC",
                table: "ProcessName",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessName_Company_CompanyId",
                schema: "QC",
                table: "ProcessName",
                column: "CompanyId",
                principalSchema: "QC",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessName_Company_CompanyId",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "QC");

            migrationBuilder.DropIndex(
                name: "IX_ProcessName_CompanyId",
                schema: "QC",
                table: "ProcessName");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "QC",
                table: "ProcessName");
        }
    }
}
