using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OllieShop.Cargo.DataAccessLayer.Migrations
{
    public partial class userIdAddedMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cargos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cargos");
        }
    }
}
