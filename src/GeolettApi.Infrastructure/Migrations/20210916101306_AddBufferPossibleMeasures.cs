using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolettApi.Infrastructure.Migrations
{
    public partial class AddBufferPossibleMeasures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BufferPossibleMeasures",
                schema: "dbo",
                table: "DataSets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BufferPossibleMeasures",
                schema: "dbo",
                table: "DataSets");
        }
    }
}
