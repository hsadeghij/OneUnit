using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00049 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfCornId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeOfCorn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfCorn", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_TypeOfCornId",
                schema: "QC",
                table: "QualityDesign",
                column: "TypeOfCornId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_TypeOfCorn_TypeOfCornId",
                schema: "QC",
                table: "QualityDesign",
                column: "TypeOfCornId",
                principalTable: "TypeOfCorn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_TypeOfCorn_TypeOfCornId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropTable(
                name: "TypeOfCorn");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_TypeOfCornId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "TypeOfCornId",
                schema: "QC",
                table: "QualityDesign");
        }
    }
}
