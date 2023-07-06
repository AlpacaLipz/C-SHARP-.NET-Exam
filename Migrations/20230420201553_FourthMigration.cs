using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Failure.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_CreatorUserId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorUserId",
                table: "Users",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_CreatorUserId",
                table: "Posts",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatorUserId",
                table: "Users",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_CreatorUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatorUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatorUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_CreatorUserId",
                table: "Posts",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
