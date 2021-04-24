using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PieGallery.Data.Migrations
{
    public partial class ImageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Comics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImage",
                table: "Comics",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
