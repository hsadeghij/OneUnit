using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeHour",
                schema: "QC",
                table: "QualityDesign",
                newName: "TransferTimeToStorage");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationTime",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "RegistrationTime",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.RenameColumn(
                name: "TransferTimeToStorage",
                schema: "QC",
                table: "QualityDesign",
                newName: "TimeHour");
        }
    }
}
