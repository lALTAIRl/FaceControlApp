namespace FaceControlApp.Persistence.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BiometricalIdentifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonName = table.Column<string>(nullable: true),
                    FaceImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiometricalIdentifiers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiometricalIdentifiers");
        }
    }
}
