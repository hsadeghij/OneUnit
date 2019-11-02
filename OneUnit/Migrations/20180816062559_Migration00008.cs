using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_ColumnNumber_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_AspNetUsers_ControllerUserId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Production_ProductionId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_AspNetUsers_SamplerId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Tank_TankId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_AspNetUsers_TesterId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_ControllerUserId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_SamplerId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropIndex(
                name: "IX_QualityDesign_TesterId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "ControllerUserId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "DateStorageTransfer",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "DateTankDrain",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "DateTankFilling",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "LevelTank",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "SamplerId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropColumn(
                name: "TesterId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.AlterColumn<int>(
                name: "TankId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductionId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_ColumnNumber_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                column: "ColumnNumberId",
                principalSchema: "QC",
                principalTable: "ColumnNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Production_ProductionId",
                schema: "QC",
                table: "QualityDesign",
                column: "ProductionId",
                principalSchema: "QC",
                principalTable: "Production",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign",
                column: "StorageId",
                principalSchema: "QC",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Tank_TankId",
                schema: "QC",
                table: "QualityDesign",
                column: "TankId",
                principalSchema: "QC",
                principalTable: "Tank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_ColumnNumber_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Production_ProductionId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityDesign_Tank_TankId",
                schema: "QC",
                table: "QualityDesign");

            migrationBuilder.AlterColumn<int>(
                name: "TankId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SamplingLocationId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerUserId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateStorageTransfer",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateTankDrain",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateTankFilling",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LevelTank",
                schema: "QC",
                table: "QualityDesign",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SamplerId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TesterId",
                schema: "QC",
                table: "QualityDesign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_ControllerUserId",
                schema: "QC",
                table: "QualityDesign",
                column: "ControllerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_SamplerId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplerId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDesign_TesterId",
                schema: "QC",
                table: "QualityDesign",
                column: "TesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_ColumnNumber_ColumnNumberId",
                schema: "QC",
                table: "QualityDesign",
                column: "ColumnNumberId",
                principalSchema: "QC",
                principalTable: "ColumnNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_AspNetUsers_ControllerUserId",
                schema: "QC",
                table: "QualityDesign",
                column: "ControllerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Production_ProductionId",
                schema: "QC",
                table: "QualityDesign",
                column: "ProductionId",
                principalSchema: "QC",
                principalTable: "Production",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_AspNetUsers_SamplerId",
                schema: "QC",
                table: "QualityDesign",
                column: "SamplerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Storage_StorageId",
                schema: "QC",
                table: "QualityDesign",
                column: "StorageId",
                principalSchema: "QC",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_Tank_TankId",
                schema: "QC",
                table: "QualityDesign",
                column: "TankId",
                principalSchema: "QC",
                principalTable: "Tank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityDesign_AspNetUsers_TesterId",
                schema: "QC",
                table: "QualityDesign",
                column: "TesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
