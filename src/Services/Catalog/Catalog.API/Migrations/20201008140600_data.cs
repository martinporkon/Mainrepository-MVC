using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "SelectedParty", "Subject", "SubscriptionLevel" },
                values: new object[] { new Guid("1eed3c41-73cc-4798-9046-578acccfd035"), "Walmart", "d860efca-22d9-47fd-8249-791ba61b07c7", "Basic" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "SelectedParty", "Subject", "SubscriptionLevel" },
                values: new object[] { new Guid("e979ff8a-e15b-4ded-9ee7-9ef46382e75b"), "Costco Wholesale", "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "FreeUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("1eed3c41-73cc-4798-9046-578acccfd035"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("e979ff8a-e15b-4ded-9ee7-9ef46382e75b"));
        }
    }
}
