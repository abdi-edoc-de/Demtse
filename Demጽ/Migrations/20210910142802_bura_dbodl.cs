using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class bura_dbodl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "Channels",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "Channels");
        }
    }
}
