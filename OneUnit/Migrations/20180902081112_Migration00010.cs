using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_DateForQualityDesign_DateForQualityDesignId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropTable(
                name: "DateForQualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_DateForQualityDesignId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "DateForQualityDesignId",
                schema: "QC",
                table: "QualityDesign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DateForQualityDesignId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DateForQualityDesign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateForQD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateForQualityDesign", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_DateForQualityDesignId",
                schema: "QC",
                table: "QualityDesign",
                column: "DateForQualityDesignId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_DateForQualityDesign_DateForQualityDesignId",
                schema: "QC",
                table: "QualityDesign",
                column: "DateForQualityDesignId",
                principalTable: "DateForQualityDesign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
