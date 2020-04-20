using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class RemoveHalls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Halls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Halls_IsDeleted",
                table: "Halls",
                column: "IsDeleted");
        }
    }
}
