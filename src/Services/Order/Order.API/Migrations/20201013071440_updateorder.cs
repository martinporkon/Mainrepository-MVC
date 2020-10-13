using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.API.Migrations
{
    public partial class updateorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressOfCustomers",
                columns: table => new
                {
                    AddressId = table.Column<string>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressOfCustomers", x => new { x.AddressId, x.CustomerId });
                });

            migrationBuilder.CreateTable(
                name: "AddressOfParties",
                columns: table => new
                {
                    AddressId = table.Column<string>(nullable: false),
                    PartyId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressOfParties", x => new { x.AddressId, x.PartyId });
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    ShipMethodsOfPartyId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ConfirmationDate = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipMethods",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipMethodsOfParties",
                columns: table => new
                {
                    PartyId = table.Column<string>(nullable: false),
                    ShipMethodId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    MinimalOrderPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethodsOfParties", x => new { x.PartyId, x.ShipMethodId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressOfCustomers");

            migrationBuilder.DropTable(
                name: "AddressOfParties");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShipMethods");

            migrationBuilder.DropTable(
                name: "ShipMethodsOfParties");
        }
    }
}
