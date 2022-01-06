using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DutyAndConductorManager.Api.Migrations
{
    public partial class AddSecurityTokenTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SecurityTokenTypeId",
                table: "SecurityTokens",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "SecurityTokenTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityTokenTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SecurityTokenTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ActivationToken" });

            migrationBuilder.InsertData(
                table: "SecurityTokenTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "PasswordChangeToken" });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTokens_SecurityTokenTypeId",
                table: "SecurityTokens",
                column: "SecurityTokenTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityTokens_SecurityTokenTypes_SecurityTokenTypeId",
                table: "SecurityTokens",
                column: "SecurityTokenTypeId",
                principalTable: "SecurityTokenTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityTokens_SecurityTokenTypes_SecurityTokenTypeId",
                table: "SecurityTokens");

            migrationBuilder.DropTable(
                name: "SecurityTokenTypes");

            migrationBuilder.DropIndex(
                name: "IX_SecurityTokens_SecurityTokenTypeId",
                table: "SecurityTokens");

            migrationBuilder.DropColumn(
                name: "SecurityTokenTypeId",
                table: "SecurityTokens");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
