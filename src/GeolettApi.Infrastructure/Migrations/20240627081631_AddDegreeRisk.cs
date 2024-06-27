using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeolettApi.Infrastructure.Migrations
{
    public partial class AddDegreeRisk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DegreeRisk",
                schema: "dbo",
                table: "RegisterItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeRisk",
                schema: "dbo",
                table: "RegisterItems");
        }
    }
}
