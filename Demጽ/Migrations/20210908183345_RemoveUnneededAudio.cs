using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class RemoveUnneededAudio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecentlyPlayeds_Audios_AudioId",
                table: "RecentlyPlayeds");

            migrationBuilder.DropIndex(
                name: "IX_RecentlyPlayeds_AudioId",
                table: "RecentlyPlayeds");

            migrationBuilder.AlterColumn<string>(
                name: "AudioId",
                table: "RecentlyPlayeds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AudioId",
                table: "RecentlyPlayeds",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_RecentlyPlayeds_AudioId",
                table: "RecentlyPlayeds",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecentlyPlayeds_Audios_AudioId",
                table: "RecentlyPlayeds",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
