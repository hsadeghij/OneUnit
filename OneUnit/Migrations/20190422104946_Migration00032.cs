using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Tran");

            migrationBuilder.AddColumn<string>(
                name: "StoreUserId1",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkType",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    PersonalCode = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    CurrentState = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: true),
                    WorkTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Post_PostId",
                        column: x => x.PostId,
                        principalSchema: "Tran",
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_WorkType_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalSchema: "Tran",
                        principalTable: "WorkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_StoreUserId1",
                table: "AspNetUserClaims",
                column: "StoreUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PostId",
                schema: "Tran",
                table: "Person",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_WorkTypeId",
                schema: "Tran",
                table: "Person",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_StoreUserId1",
                table: "AspNetUserClaims",
                column: "StoreUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_StoreUserId1",
                table: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "WorkType",
                schema: "Tran");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_StoreUserId1",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "StoreUserId1",
                table: "AspNetUserClaims");
        }
    }
}
