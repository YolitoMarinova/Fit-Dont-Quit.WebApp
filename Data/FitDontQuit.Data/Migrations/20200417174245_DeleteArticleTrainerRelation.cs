using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class DeleteArticleTrainerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Trainers_TrainerId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TrainerId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Trainers",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TrainerId",
                table: "Articles",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Trainers_TrainerId",
                table: "Articles",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
