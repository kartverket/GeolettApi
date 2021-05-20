using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolettApi.Infrastructure.Migrations
{
    public partial class AddRegisterItemUuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                schema: "dbo",
                table: "RegisterItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                schema: "dbo",
                table: "RegisterItems");
        }
    }
}
