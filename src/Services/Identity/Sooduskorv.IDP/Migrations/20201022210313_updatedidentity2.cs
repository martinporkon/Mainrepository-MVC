using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sooduskorv.IDP.Migrations
{
    public partial class updatedidentity2 : Migration
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
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "ecb5e28c-672e-4a53-90c1-da4c66ec4233", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Hanna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "3afbf0bb-8bac-4008-8fb4-145d30ed15e1", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Bob" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("951367ba-7612-4ef8-aaa8-bffe6a6df6ce"), "1a387282-0359-4119-992f-89995463c44b", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Hanna" },
                    { new Guid("3ba77647-9ca1-462f-906a-6b83fbf2319c"), "1cf86806-dcb2-42a3-931f-63c5f9dfdd32", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Forest" },
                    { new Guid("4d0a979e-cbf1-4784-8cb3-3dd959ba02fc"), "1e235272-2329-4ae8-bc9c-777100bd9c40", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "hanna@gmail.com" },
                    { new Guid("df92fb28-af77-4f0d-965a-22efbd55fd71"), "a8791ae3-4e2d-4ec7-8ff8-fb9972ac47eb", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Tammsaare tee" },
                    { new Guid("e36dcf75-b61d-4b3b-a7c0-ce8eca2cbbfd"), "af50f5f6-16a1-4e41-bcd0-45c56a465eb7", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "somevalue" },
                    { new Guid("0181cf8b-885e-48b9-8ce7-8d89c306d5cb"), "66bc5aad-eece-43ed-b475-2d2119395220", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Bob" },
                    { new Guid("0e382ebf-753d-4730-8943-89f4fd0e0729"), "09e56976-4cb9-43b1-9d1a-4c23f50e322d", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Oak" },
                    { new Guid("36a56545-7bda-4dcc-a8c0-d4c72cbaf23c"), "870edf9c-d9c0-4441-a0c6-a6a9d5fd5e26", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "bob@gmail.com" },
                    { new Guid("9c0b2632-42e0-45cf-bfd2-3c9c58547b74"), "ae92156f-ffc3-4a4c-81c9-c8cdd0efc6d4", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Ehitajate Tee" },
                    { new Guid("bfe72e5b-93eb-432d-8297-b638a4d8d5dd"), "0ac77062-ba72-47a4-b712-36216cc5bea0", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "somevalue" }
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
