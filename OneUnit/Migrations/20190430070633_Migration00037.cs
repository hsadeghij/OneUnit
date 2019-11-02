using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00037 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransitInfo",
                schema: "Tran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    DateReg = table.Column<string>(nullable: true),
                    RatingId = table.Column<byte>(nullable: false),
                    CurrentStateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransitInfo_CurrentState_CurrentStateId",
                        column: x => x.CurrentStateId,
                        principalSchema: "Tran",
                        principalTable: "CurrentState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransitInfo_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Tran",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransitInfo_Rating_RatingId",
                        column: x => x.RatingId,
                        principalSchema: "Tran",
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransitInfo_CurrentStateId",
                schema: "Tran",
                table: "TransitInfo",
                column: "CurrentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_TransitInfo_PersonId",
                schema: "Tran",
                table: "TransitInfo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TransitInfo_RatingId",
                schema: "Tran",
                table: "TransitInfo",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransitInfo",
                schema: "Tran");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "Tran");
        }
    }
}
