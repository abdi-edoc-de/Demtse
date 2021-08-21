using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class debug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_Channels_UserId",
                table: "Channels");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Channels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_Channels_UserId",
                table: "Channels");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Channels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
