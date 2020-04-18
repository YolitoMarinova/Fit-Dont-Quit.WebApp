using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class Migrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainings_Halls_HallId",
                table: "GroupTrainings");

            migrationBuilder.DropIndex(
                name: "IX_GroupTrainings_HallId",
                table: "GroupTrainings");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "GroupTrainings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "GroupTrainings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_HallId",
                table: "GroupTrainings",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainings_Halls_HallId",
                table: "GroupTrainings",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
