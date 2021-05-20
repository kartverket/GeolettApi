using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolettApi.Infrastructure.Migrations
{
    public partial class AddRegisterOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                schema: "dbo",
                table: "RegisterItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterItems_OwnerId",
                schema: "dbo",
                table: "RegisterItems",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterItems_Organizations_OwnerId",
                schema: "dbo",
                table: "RegisterItems",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterItems_Organizations_OwnerId",
                schema: "dbo",
                table: "RegisterItems");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_RegisterItems_OwnerId",
                schema: "dbo",
                table: "RegisterItems");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "RegisterItems");
        }
    }
}
