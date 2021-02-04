using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZELF.SocialNetwork.EFData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Raiting = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscribers",
                columns: table => new
                {
                    FromUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ToUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreateUser = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedUser = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscribers", x => new { x.FromUserId, x.ToUserId });
                    table.ForeignKey(
                        name: "FK_UserSubscribers_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubscribers_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Raiting",
                table: "Users",
                column: "Raiting");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscribers_FromUserId_ToUserId",
                table: "UserSubscribers",
                columns: new[] { "FromUserId", "ToUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscribers_ToUserId",
                table: "UserSubscribers",
                column: "ToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSubscribers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
