using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sooduskorv.IDP.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "43a1089d-7d9f-459b-933a-b972f8b74da4", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Hanna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "ddc2ed61-89ad-4fc6-884d-74712d8790c0", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Bob" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("cb0d22a8-82ae-4193-8808-5900a1a935e4"), "d4eb18cf-1a15-499f-8126-9061f9fd532f", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Hanna" },
                    { new Guid("0fdc425c-238e-434e-80b3-92b911e4699d"), "77f4f5bc-d6ea-42a6-a8f7-08e722e84c3d", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Forest" },
                    { new Guid("eec1a9cf-a1a7-44f8-a86a-8efc740dff2c"), "759cce95-ad9c-4f80-a461-e91d74b94e1f", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "hanna@gmail.com" },
                    { new Guid("d2eb807a-479a-4cc6-bd3f-5b95cbb21aa0"), "0be1e82f-2771-4e46-a474-f3482031b431", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Tammsaare tee" },
                    { new Guid("4699d3a1-285e-4e18-b5de-3adecdd2f1c2"), "0179af08-3b4c-47e7-b72c-566d1a458e72", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "somevalue" },
                    { new Guid("23177980-98f8-4665-a182-80eb5f9eacd3"), "8ee8c5eb-87aa-4be4-a323-83c7c169a00f", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Bob" },
                    { new Guid("c1be34c9-12fc-4586-abf4-f962699e8bd1"), "a6368173-b6e1-4d16-8b8c-bf9419ff7d1d", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Oak" },
                    { new Guid("8182e5f8-2ffa-48b4-b927-827db50c3922"), "165edc20-5885-4041-b718-ef846824b73e", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "bob@gmail.com" },
                    { new Guid("715e1d47-d9f1-41c8-93c5-5a3733bce654"), "9cf2b87d-cfc9-495d-8843-4d3cb771c6fd", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Ehitajate Tee" },
                    { new Guid("302b6fba-9fcb-4584-9224-8ac17f9e485c"), "4bb46d84-dc2f-4beb-bccd-fd90d1191927", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "somevalue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
