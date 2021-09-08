using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class AddRecentlyPlayedReally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecentlyPlayeds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AudioId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ListenTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentlyPlayeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecentlyPlayeds_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecentlyPlayeds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecentlyPlayeds_AudioId",
                table: "RecentlyPlayeds",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_RecentlyPlayeds_UserId",
                table: "RecentlyPlayeds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecentlyPlayeds");
        }
    }
}
