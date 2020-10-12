using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sooduskorv.IDP.Migrations
{
    public partial class migratsioon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 200, nullable: false),
                    Username = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    SecurityCode = table.Column<string>(maxLength: 200, nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
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
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "fb659bc3-716c-40c1-806b-411c4f467b91", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Hanna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "24e7b3cc-dcc0-403f-aa1b-a5746843531c", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Bob" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("e43d9f5d-5f4b-48c3-8ba8-a45c51243037"), "bdca089d-bfef-4f69-a463-a6a63011472b", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Hanna" },
                    { new Guid("c6be05c8-c577-4536-a8a9-50364c0a7675"), "65e73c27-ea78-4bbb-89b4-de8785e7b175", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Forest" },
                    { new Guid("becf17df-c8fa-4632-8042-a8d335707c02"), "b28c9ce3-8b56-43c1-b875-ee22ba2e4cee", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "hanna@gmail.com" },
                    { new Guid("48b3bf4f-ef15-42a2-9171-bd094da9d292"), "f03dc117-aa4e-4849-ae84-ca9a3d224372", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Tammsaare tee" },
                    { new Guid("3728a6f7-e7c3-4c8d-9a6b-7640231e859d"), "2b57af27-6089-43d3-9802-48dfb48512e8", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "somevalue" },
                    { new Guid("daddc47e-10c2-404c-b700-b390eac82a90"), "583e66a4-b73b-4e65-a006-cf1adfebfcf4", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Bob" },
                    { new Guid("1f3dcc8f-3fe0-4c8c-a2c9-a19416a5e25b"), "813f33fb-f38f-495c-83c4-9b35572ba58b", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Oak" },
                    { new Guid("8508f92a-a41a-4693-92a4-9c3bed3a4c0d"), "176fb608-2304-497a-85a9-37662d7f6523", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "bob@gmail.com" },
                    { new Guid("90a94824-c0c1-458d-8aae-fb817446f09e"), "309d953b-2438-42da-939a-3d000a3b46ee", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Ehitajate Tee" },
                    { new Guid("e272e5b5-4011-43f6-90db-42f7df361ff6"), "567e0836-67f8-41de-89a7-6fa94beebe77", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "somevalue" }
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
