using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class AddRecentlyPlayed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfListeners",
                table: "Audios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfListeners",
                table: "Audios");
        }
    }
}
