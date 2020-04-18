using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class AddClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainings_Trainers_TrainerId",
                table: "GroupTrainings");

            migrationBuilder.DropTable(
                name: "UsersGroupTrainings");

            migrationBuilder.DropIndex(
                name: "IX_GroupTrainings_TrainerId",
                table: "GroupTrainings");

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

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "GroupTrainings");

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "GroupTrainings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    GroupTrainingId = table.Column<int>(nullable: false),
                    TrainerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_GroupTrainings_GroupTrainingId",
                        column: x => x.GroupTrainingId,
                        principalTable: "GroupTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GroupTrainingId",
                table: "Classes",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainerId",
                table: "Classes",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "GroupTrainings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "GroupTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "GroupTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndHour",
                table: "GroupTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "GroupTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "GroupTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsersGroupTrainings",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupTrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroupTrainings", x => new { x.UserId, x.GroupTrainingId });
                    table.ForeignKey(
                        name: "FK_UsersGroupTrainings_GroupTrainings_GroupTrainingId",
                        column: x => x.GroupTrainingId,
                        principalTable: "GroupTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersGroupTrainings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_TrainerId",
                table: "GroupTrainings",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroupTrainings_GroupTrainingId",
                table: "UsersGroupTrainings",
                column: "GroupTrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainings_Trainers_TrainerId",
                table: "GroupTrainings",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
