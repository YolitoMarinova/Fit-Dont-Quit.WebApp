using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class FixMembershipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfPeopleLimit",
                table: "Memberships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HaveATrainer",
                table: "Memberships",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VisitLimit",
                table: "Memberships",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfPeopleLimit",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "HaveATrainer",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "VisitLimit",
                table: "Memberships");
        }
    }
}
