using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceControlApp.Persistence.Migrations
{
    public partial class ImageBase64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaceImage",
                table: "BiometricalIdentifiers",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "FaceImage",
                table: "BiometricalIdentifiers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
