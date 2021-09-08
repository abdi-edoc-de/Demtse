using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class sampleC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Description", "Name", "ProfilePicture", "UserId" },
                values: new object[] { "102b566b-ba1f-404c-b2df-e2cde39ade09", "This is a cool podcast where we interview inanimate objects", "Everything is Alive", "So this should be a path to profile pics", "261672a7-358b-4b6c-8ff3-6f7358999f6b" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Description", "Name", "ProfilePicture", "UserId" },
                values: new object[] { "2902b665-1190-4c70-9915-b9c2d7680450", "This is a Not cool podcast where we interview inanimate objects", "Everything is Not Alive", "So this should Not be a path to profile pics", "2545b40c-004f-43a7-883d-336422040b17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: "102b566b-ba1f-404c-b2df-e2cde39ade09");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: "2902b665-1190-4c70-9915-b9c2d7680450");
        }
    }
}
