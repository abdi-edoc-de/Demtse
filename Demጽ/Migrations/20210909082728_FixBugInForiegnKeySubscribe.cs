using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class FixBugInForiegnKeySubscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserID",
                table: "Subscribtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribtions",
                table: "Subscribtions");

            migrationBuilder.DropIndex(
                name: "IX_Subscribtions_UserID",
                table: "Subscribtions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subscribtions");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Subscribtions",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Subscribtions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribtions",
                table: "Subscribtions",
                columns: new[] { "UserId", "ChannelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserId",
                table: "Subscribtions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserId",
                table: "Subscribtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribtions",
                table: "Subscribtions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Subscribtions",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Subscribtions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Subscribtions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribtions",
                table: "Subscribtions",
                columns: new[] { "UserId", "ChannelId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribtions_UserID",
                table: "Subscribtions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserID",
                table: "Subscribtions",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
