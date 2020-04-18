using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class EditGrouupTrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "GroupTrainings");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "GroupTrainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "GroupTrainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndHour",
                table: "GroupTrainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "GroupTrainings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "GroupTrainings");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "GroupTrainings");

            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "GroupTrainings");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "GroupTrainings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "GroupTrainings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
