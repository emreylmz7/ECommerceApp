using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OllieShop.Cargo.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_CargoCompanies_CargoCompanyId",
                table: "CargoDetails");

            migrationBuilder.DropTable(
                name: "CargoCompanies");

            migrationBuilder.DropTable(
                name: "CargoCustomers");

            migrationBuilder.DropTable(
                name: "CargoOperations");

            migrationBuilder.DropIndex(
                name: "IX_CargoDetails_CargoCompanyId",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "ReceiverCustomer",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "SenderCustomer",
                table: "CargoDetails");

            migrationBuilder.RenameColumn(
                name: "CargoCompanyId",
                table: "CargoDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "CargoDetails",
                newName: "CargoId");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CargoDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "CargoDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "CargoDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoId",
                table: "CargoDetails",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_Cargos_CargoId",
                table: "CargoDetails",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_Cargos_CargoId",
                table: "CargoDetails");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_CargoDetails_CargoId",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "CargoDetails");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CargoDetails",
                newName: "CargoCompanyId");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "CargoDetails",
                newName: "Barcode");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverCustomer",
                table: "CargoDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderCustomer",
                table: "CargoDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CargoCompanies",
                columns: table => new
                {
                    CargoCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCompanies", x => x.CargoCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CargoCustomers",
                columns: table => new
                {
                    CargoCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCustomers", x => x.CargoCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CargoOperations",
                columns: table => new
                {
                    CargoOperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOperations", x => x.CargoOperationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCompanyId",
                table: "CargoDetails",
                column: "CargoCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_CargoCompanies_CargoCompanyId",
                table: "CargoDetails",
                column: "CargoCompanyId",
                principalTable: "CargoCompanies",
                principalColumn: "CargoCompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
