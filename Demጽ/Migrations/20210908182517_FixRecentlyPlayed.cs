using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class FixRecentlyPlayed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecentlyPlayeds_AspNetUsers_UserId",
                table: "RecentlyPlayeds");

            migrationBuilder.DropIndex(
                name: "IX_RecentlyPlayeds_UserId",
                table: "RecentlyPlayeds");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecentlyPlayeds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecentlyPlayeds",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_RecentlyPlayeds_UserId",
                table: "RecentlyPlayeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecentlyPlayeds_AspNetUsers_UserId",
                table: "RecentlyPlayeds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
