using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OllieShop.Cargo.DataAccessLayer.Migrations
{
    public partial class AddReceiverCustomerMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverCustomer",
                table: "CargoDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CargoCompanyName",
                table: "CargoCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverCustomer",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "CargoCompanyName",
                table: "CargoCompanies");
        }
    }
}
