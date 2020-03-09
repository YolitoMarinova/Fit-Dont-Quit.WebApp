using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class DeleteUsersGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersGroupTrainings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersGroupTrainings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupTrainingId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_UsersGroupTrainings_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroupTrainings_GroupTrainingId",
                table: "UsersGroupTrainings",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroupTrainings_UserId1",
                table: "UsersGroupTrainings",
                column: "UserId1");
        }
    }
}
