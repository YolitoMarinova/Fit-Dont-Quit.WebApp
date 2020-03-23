namespace FitDontQuit.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trainers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "Trainers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    TrainerId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    SeatsCount = table.Column<int>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    HallIde = table.Column<int>(nullable: false),
                    HallId = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembershipsServices",
                columns: table => new
                {
                    MembershipId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipsServices", x => new { x.MembershipId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_MembershipsServices_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipsServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersGroupTrainings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupTrainingId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
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
                name: "IX_Trainers_ProfessionId",
                table: "Trainers",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IsDeleted",
                table: "Articles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TrainerId",
                table: "Articles",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_HallId",
                table: "GroupTrainings",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_IsDeleted",
                table: "GroupTrainings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_TrainerId",
                table: "GroupTrainings",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_IsDeleted",
                table: "Halls",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_IsDeleted",
                table: "Memberships",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipsServices_ServiceId",
                table: "MembershipsServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_IsDeleted",
                table: "Professions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Services_IsDeleted",
                table: "Services",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroupTrainings_GroupTrainingId",
                table: "UsersGroupTrainings",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroupTrainings_UserId1",
                table: "UsersGroupTrainings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Professions_ProfessionId",
                table: "Trainers",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Professions_ProfessionId",
                table: "Trainers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "MembershipsServices");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "UsersGroupTrainings");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_ProfessionId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
