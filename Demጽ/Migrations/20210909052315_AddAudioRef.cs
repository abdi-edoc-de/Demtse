using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class AddAudioRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AudioId",
                table: "RecentlyPlayeds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
