using Microsoft.EntityFrameworkCore.Migrations;

namespace Demጽ.Migrations
{
    public partial class sampleD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Description", "Name", "ProfilePicture", "UserId" },
                values: new object[] { "2ee49fe3-edf2-4f91-8409-3eb25ce6ca51", "This is desc", "Third Channel", "Selfie", "0581520d-52f6-4f56-af85-efd6a3ca79df" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: "2ee49fe3-edf2-4f91-8409-3eb25ce6ca51");
        }
    }
}
