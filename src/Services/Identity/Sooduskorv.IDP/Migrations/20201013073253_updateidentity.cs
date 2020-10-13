using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sooduskorv.IDP.Migrations
{
    public partial class updateidentity : Migration
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
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "a17a31a3-dbe1-49b5-8309-509177aa216d", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Hanna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "9fa81eab-21d3-467e-8b97-97c1f41a5238", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Bob" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0ad8ae94-8b17-4c0e-8c50-fd82e6bfa5b8"), "87445fc7-c393-426f-a6c3-b38d504cb85d", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Hanna" },
                    { new Guid("eb7c549c-c993-4b8a-94e1-5e886dfc238d"), "371d8329-58a8-47c0-8982-e45acce76889", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Forest" },
                    { new Guid("10728f2b-8d91-4729-b4ec-211ae92043a4"), "44b1d924-3dc3-4ebf-b610-9b6a4cf70ce1", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "hanna@gmail.com" },
                    { new Guid("db39a0ba-6c31-4d21-a07b-9e1a53ec65b1"), "13665859-6dc7-4e14-9901-50d59cbed5cf", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Tammsaare tee" },
                    { new Guid("cb2df5a1-0bcc-4e9d-8f01-6ba1adf8d999"), "0cee4d96-5ed2-479f-af1c-e3ada6f305fb", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "somevalue" },
                    { new Guid("0aebc33c-c43c-43e8-9362-53b54a0a71db"), "3c3e9f54-8746-4422-bd21-c204813a01b5", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Bob" },
                    { new Guid("11874f81-4785-4cfd-9ed8-5f2df8f050a0"), "f9eceeaa-1610-4a23-8700-0c027ebf509b", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Oak" },
                    { new Guid("85b4f8ef-7023-41b6-ae85-a0d1c7001101"), "dd7d60f6-08f0-4cad-bc5e-0528797ef59c", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "bob@gmail.com" },
                    { new Guid("f1195b3b-6676-4942-9c2c-ac31b1f905b1"), "435db47d-66d4-41de-a01b-9e34854b15e4", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Ehitajate Tee" },
                    { new Guid("0ec3dca5-5e30-4753-a81e-d806bdb24625"), "61f778fe-0f5e-4dcf-b7f6-b3f13dad2678", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "somevalue" }
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
