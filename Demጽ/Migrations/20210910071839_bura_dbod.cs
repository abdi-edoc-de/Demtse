using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class bura_dbod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Channels_ChannelId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_RecentlyPlayeds_Audios_AudioId",
                table: "RecentlyPlayeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_Channels_ChannelId",
                table: "Subscribtions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserId",
                table: "Subscribtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentlyPlayeds",
                table: "RecentlyPlayeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Channels",
                table: "Channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audios",
                table: "Audios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "Subscribtions");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "RecentlyPlayeds");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ChaId",
                table: "AspNetRoleClaims");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Subscribtions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "RecentlyPlayeds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Channels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Audios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentlyPlayeds",
                table: "RecentlyPlayeds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Channels",
                table: "Channels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audios",
                table: "Audios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Channels_ChannelId",
                table: "Audios",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecentlyPlayeds_Audios_AudioId",
                table: "RecentlyPlayeds",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Channels_ChannelId",
                table: "Subscribtions",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Channels_ChannelId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_RecentlyPlayeds_Audios_AudioId",
                table: "RecentlyPlayeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_Channels_ChannelId",
                table: "Subscribtions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserId",
                table: "Subscribtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentlyPlayeds",
                table: "RecentlyPlayeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Channels",
                table: "Channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audios",
                table: "Audios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Subscribtions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RecentlyPlayeds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetRoleClaims");

            migrationBuilder.AddColumn<string>(
                name: "ChaId",
                table: "Subscribtions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChaId",
                table: "RecentlyPlayeds",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChaId",
                table: "Channels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChaId",
                table: "Audios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChaId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ChaId",
                table: "AspNetUserClaims",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ChaId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ChaId",
                table: "AspNetRoleClaims",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentlyPlayeds",
                table: "RecentlyPlayeds",
                column: "ChaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Channels",
                table: "Channels",
                column: "ChaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audios",
                table: "Audios",
                column: "ChaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "ChaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "ChaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "ChaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "ChaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Channels_ChannelId",
                table: "Audios",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_AspNetUsers_UserId",
                table: "Channels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecentlyPlayeds_Audios_AudioId",
                table: "RecentlyPlayeds",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Channels_ChannelId",
                table: "Subscribtions",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_AspNetUsers_UserId",
                table: "Subscribtions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "ChaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
