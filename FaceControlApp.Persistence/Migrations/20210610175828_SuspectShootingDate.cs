using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceControlApp.Persistence.Migrations
{
    public partial class SuspectShootingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShootingDate",
                table: "Suspects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShootingDate",
                table: "Suspects");
        }
    }
}
