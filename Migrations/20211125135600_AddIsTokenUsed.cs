using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DutyAndConductorManager.Api.Migrations
{
    public partial class AddIsTokenUsed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "SecurityTokens",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "SecurityTokens");
        }
    }
}
