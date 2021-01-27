using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolettApi.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RegisterItems",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialogText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PossibleMeasures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guidance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterItemId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_RegisterItems_RegisterItemId",
                        column: x => x.RegisterItemId,
                        principalSchema: "dbo",
                        principalTable: "RegisterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_RegisterItemId",
                schema: "dbo",
                table: "Links",
                column: "RegisterItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RegisterItems",
                schema: "dbo");
        }
    }
}
