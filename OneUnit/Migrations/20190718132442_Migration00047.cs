using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneUnit.Migrations
{
    public partial class Migration00047 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Tran",
                table: "Attachment");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Tran",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicUrl",
                schema: "Tran",
                table: "Attachment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Tran",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "PicUrl",
                schema: "Tran",
                table: "Attachment");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Tran",
                table: "Attachment",
                nullable: true);
        }
    }
}
