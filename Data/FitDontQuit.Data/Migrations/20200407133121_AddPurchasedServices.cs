using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitDontQuit.Data.Migrations
{
    public partial class AddPurchasedServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMembership_Memberships_MembershipId",
                table: "PurchasedMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMembership_AspNetUsers_UserId",
                table: "PurchasedMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedMembership",
                table: "PurchasedMembership");

            migrationBuilder.RenameTable(
                name: "PurchasedMembership",
                newName: "PurchasedMemberships");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMembership_UserId",
                table: "PurchasedMemberships",
                newName: "IX_PurchasedMemberships_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMembership_MembershipId",
                table: "PurchasedMemberships",
                newName: "IX_PurchasedMemberships_MembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMembership_IsDeleted",
                table: "PurchasedMemberships",
                newName: "IX_PurchasedMemberships_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedMemberships",
                table: "PurchasedMemberships",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PurchasedServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasedServices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedServices_IsDeleted",
                table: "PurchasedServices",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedServices_ServiceId",
                table: "PurchasedServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedServices_UserId",
                table: "PurchasedServices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMemberships_Memberships_MembershipId",
                table: "PurchasedMemberships",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMemberships_AspNetUsers_UserId",
                table: "PurchasedMemberships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMemberships_Memberships_MembershipId",
                table: "PurchasedMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMemberships_AspNetUsers_UserId",
                table: "PurchasedMemberships");

            migrationBuilder.DropTable(
                name: "PurchasedServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedMemberships",
                table: "PurchasedMemberships");

            migrationBuilder.RenameTable(
                name: "PurchasedMemberships",
                newName: "PurchasedMembership");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMemberships_UserId",
                table: "PurchasedMembership",
                newName: "IX_PurchasedMembership_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMemberships_MembershipId",
                table: "PurchasedMembership",
                newName: "IX_PurchasedMembership_MembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMemberships_IsDeleted",
                table: "PurchasedMembership",
                newName: "IX_PurchasedMembership_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedMembership",
                table: "PurchasedMembership",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMembership_Memberships_MembershipId",
                table: "PurchasedMembership",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMembership_AspNetUsers_UserId",
                table: "PurchasedMembership",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
