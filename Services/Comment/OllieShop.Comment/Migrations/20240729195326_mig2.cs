using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OllieShop.Comment.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Comments",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserSurname",
                table: "Comments",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "UseImageUrl",
                table: "Comments",
                newName: "UserImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Comments",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UserImageUrl",
                table: "Comments",
                newName: "UseImageUrl");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Comments",
                newName: "UserSurname");
        }
    }
}
