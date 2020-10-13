using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.API.Migrations
{
    public partial class updatebasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketOfProducts",
                columns: table => new
                {
                    BasketId = table.Column<string>(nullable: false),
                    ProductOfPartyId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketOfProducts", x => new { x.BasketId, x.ProductOfPartyId });
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketOfProducts");

            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
