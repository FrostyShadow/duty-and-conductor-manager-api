using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DutyAndConductorManager.Api.Migrations
{
    public partial class AddForgotPasswordToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SecurityTokenTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "ForgotPasswordToken" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SecurityTokenTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
