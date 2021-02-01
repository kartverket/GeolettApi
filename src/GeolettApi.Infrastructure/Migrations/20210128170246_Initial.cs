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
                name: "Links",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "References",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tek17Id = table.Column<int>(type: "int", nullable: true),
                    OtherLawId = table.Column<int>(type: "int", nullable: true),
                    CircularFromMinistryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_Links_CircularFromMinistryId",
                        column: x => x.CircularFromMinistryId,
                        principalSchema: "dbo",
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_References_Links_OtherLawId",
                        column: x => x.OtherLawId,
                        principalSchema: "dbo",
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_References_Links_Tek17Id",
                        column: x => x.Tek17Id,
                        principalSchema: "dbo",
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlMetadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BufferDistance = table.Column<int>(type: "int", nullable: true),
                    BufferText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlGmlSchema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSets_ObjectTypes_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalSchema: "dbo",
                        principalTable: "ObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterItems",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContextType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialogText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PossibleMeasures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guidance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSetId = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    TechnicalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sign1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sign2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sign3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sign4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sign5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sign6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterItems_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalSchema: "dbo",
                        principalTable: "DataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterItems_References_ReferenceId",
                        column: x => x.ReferenceId,
                        principalSchema: "dbo",
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterItemLinks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterItemId = table.Column<int>(type: "int", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterItemLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterItemLinks_Links_LinkId",
                        column: x => x.LinkId,
                        principalSchema: "dbo",
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterItemLinks_RegisterItems_RegisterItemId",
                        column: x => x.RegisterItemId,
                        principalSchema: "dbo",
                        principalTable: "RegisterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_ObjectTypeId",
                schema: "dbo",
                table: "DataSets",
                column: "ObjectTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_References_CircularFromMinistryId",
                schema: "dbo",
                table: "References",
                column: "CircularFromMinistryId",
                unique: true,
                filter: "[CircularFromMinistryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_References_OtherLawId",
                schema: "dbo",
                table: "References",
                column: "OtherLawId",
                unique: true,
                filter: "[OtherLawId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_References_Tek17Id",
                schema: "dbo",
                table: "References",
                column: "Tek17Id",
                unique: true,
                filter: "[Tek17Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterItemLinks_LinkId",
                schema: "dbo",
                table: "RegisterItemLinks",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterItemLinks_RegisterItemId",
                schema: "dbo",
                table: "RegisterItemLinks",
                column: "RegisterItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterItems_DataSetId",
                schema: "dbo",
                table: "RegisterItems",
                column: "DataSetId",
                unique: true,
                filter: "[DataSetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterItems_ReferenceId",
                schema: "dbo",
                table: "RegisterItems",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterItemLinks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RegisterItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DataSets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "References",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ObjectTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Links",
                schema: "dbo");
        }
    }
}
