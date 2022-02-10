using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DutyAndConductorManager.Api.Migrations
{
    public partial class AddBrigadeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_LineType_LineTypeId",
                table: "Line");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineType",
                table: "LineType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Line",
                table: "Line");

            migrationBuilder.RenameTable(
                name: "LineType",
                newName: "LineTypes");

            migrationBuilder.RenameTable(
                name: "Line",
                newName: "Lines");

            migrationBuilder.RenameIndex(
                name: "IX_Line_LineTypeId",
                table: "Lines",
                newName: "IX_Lines_LineTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineTypes",
                table: "LineTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lines",
                table: "Lines",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Brigades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConductorLimit = table.Column<int>(type: "int", nullable: false),
                    SetId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brigades_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brigades_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrigadeUsers",
                columns: table => new
                {
                    BrigadeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrigadeUsers", x => new { x.BrigadeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BrigadeUsers_Brigades_BrigadeId",
                        column: x => x.BrigadeId,
                        principalTable: "Brigades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrigadeUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_LineId",
                table: "Brigades",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_SetId",
                table: "Brigades",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeUsers_UserId",
                table: "BrigadeUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_LineTypes_LineTypeId",
                table: "Lines",
                column: "LineTypeId",
                principalTable: "LineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lines_LineTypes_LineTypeId",
                table: "Lines");

            migrationBuilder.DropTable(
                name: "BrigadeUsers");

            migrationBuilder.DropTable(
                name: "Brigades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineTypes",
                table: "LineTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lines",
                table: "Lines");

            migrationBuilder.RenameTable(
                name: "LineTypes",
                newName: "LineType");

            migrationBuilder.RenameTable(
                name: "Lines",
                newName: "Line");

            migrationBuilder.RenameIndex(
                name: "IX_Lines_LineTypeId",
                table: "Line",
                newName: "IX_Line_LineTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineType",
                table: "LineType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Line",
                table: "Line",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Line_LineType_LineTypeId",
                table: "Line",
                column: "LineTypeId",
                principalTable: "LineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
