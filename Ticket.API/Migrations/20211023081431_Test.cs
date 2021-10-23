using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorYoutubeDl.Api.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "uploadSite",
                table: "Videos",
                newName: "UploadSite");

            migrationBuilder.RenameColumn(
                name: "thunmbnailUrl",
                table: "Videos",
                newName: "ThunmbnailUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadSite",
                table: "Videos",
                newName: "uploadSite");

            migrationBuilder.RenameColumn(
                name: "ThunmbnailUrl",
                table: "Videos",
                newName: "thunmbnailUrl");
        }
    }
}
