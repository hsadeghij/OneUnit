using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_ControlParameterType_ControlParameterTypeId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_ControlTools_ControlToolsId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_OrganizationalUnit_RControlId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_SamplingFrequency_SamplingFrequencyId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_StandardA_StandardAId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_StandardP_StandardPId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropTable(
                name: "ControlParameterType",
                schema: "QC");

            migrationBuilder.DropTable(
                name: "ControlTools",
                schema: "QC");

            migrationBuilder.DropTable(
                name: "SamplingFrequency",
                schema: "QC");

            migrationBuilder.DropTable(
                name: "StandardA",
                schema: "QC");

            migrationBuilder.DropTable(
                name: "StandardP",
                schema: "QC");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_ControlParameterTypeId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_ControlToolsId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_RControlId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_SamplingFrequencyId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_StandardAId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_StandardPId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "ControlParameterTypeId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "ControlToolsId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "RControlId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "StandardAId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "StandardPId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationalUnitId",
                schema: "QC",
                table: "ControlParameter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_OrganizationalUnitId",
                schema: "QC",
                table: "ControlParameter",
                column: "OrganizationalUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_OrganizationalUnit_OrganizationalUnitId",
                schema: "QC",
                table: "ControlParameter",
                column: "OrganizationalUnitId",
                principalSchema: "QC",
                principalTable: "OrganizationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlParameter_OrganizationalUnit_OrganizationalUnitId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropIndex(
                name: "IX_ControlParameter_OrganizationalUnitId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.DropColumn(
                name: "OrganizationalUnitId",
                schema: "QC",
                table: "ControlParameter");

            migrationBuilder.AddColumn<int>(
                name: "ControlParameterTypeId",
                schema: "QC",
                table: "ControlParameter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ControlToolsId",
                schema: "QC",
                table: "ControlParameter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RControlId",
                schema: "QC",
                table: "ControlParameter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandardAId",
                schema: "QC",
                table: "ControlParameter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandardPId",
                schema: "QC",
                table: "ControlParameter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ControlParameterType",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlParameterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlTools",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlTools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SamplingFrequency",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamplingFrequency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardA",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardP",
                schema: "QC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardP", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_ControlParameterTypeId",
                schema: "QC",
                table: "ControlParameter",
                column: "ControlParameterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_ControlToolsId",
                schema: "QC",
                table: "ControlParameter",
                column: "ControlToolsId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_RControlId",
                schema: "QC",
                table: "ControlParameter",
                column: "RControlId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_SamplingFrequencyId",
                schema: "QC",
                table: "ControlParameter",
                column: "SamplingFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_StandardAId",
                schema: "QC",
                table: "ControlParameter",
                column: "StandardAId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlParameter_StandardPId",
                schema: "QC",
                table: "ControlParameter",
                column: "StandardPId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_ControlParameterType_ControlParameterTypeId",
                schema: "QC",
                table: "ControlParameter",
                column: "ControlParameterTypeId",
                principalSchema: "QC",
                principalTable: "ControlParameterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_ControlTools_ControlToolsId",
                schema: "QC",
                table: "ControlParameter",
                column: "ControlToolsId",
                principalSchema: "QC",
                principalTable: "ControlTools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_OrganizationalUnit_RControlId",
                schema: "QC",
                table: "ControlParameter",
                column: "RControlId",
                principalSchema: "QC",
                principalTable: "OrganizationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_SamplingFrequency_SamplingFrequencyId",
                schema: "QC",
                table: "ControlParameter",
                column: "SamplingFrequencyId",
                principalSchema: "QC",
                principalTable: "SamplingFrequency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_StandardA_StandardAId",
                schema: "QC",
                table: "ControlParameter",
                column: "StandardAId",
                principalSchema: "QC",
                principalTable: "StandardA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlParameter_StandardP_StandardPId",
                schema: "QC",
                table: "ControlParameter",
                column: "StandardPId",
                principalSchema: "QC",
                principalTable: "StandardP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
