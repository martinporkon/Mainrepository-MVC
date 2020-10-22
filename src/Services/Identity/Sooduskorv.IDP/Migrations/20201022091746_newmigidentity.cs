using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sooduskorv.IDP.Migrations
{
    public partial class newmigidentity : Migration
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
                name: "UserClaim",
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
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "12496d54-2af7-4baf-aedd-74357d600081", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Hanna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "6cecafbc-7b6d-4cfb-a1d5-f15d5f711be9", null, "password", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Bob" });

            migrationBuilder.InsertData(
                table: "UserClaim",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("a1c80b31-2b9a-47a3-b326-06c5b28175c5"), "ed554760-c325-4863-9095-077c501888f9", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Hanna" },
                    { new Guid("179069d4-10a3-4ec2-9d57-67f20eecd9b9"), "e4a22069-9643-4daf-8572-69f86e0f7be5", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Forest" },
                    { new Guid("c079d835-37a6-4cb1-95de-95b007fa0b29"), "e9920b4d-646d-43c8-9e61-e4ef8c033524", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "hanna@gmail.com" },
                    { new Guid("0d2a5459-e20b-4513-8b39-5b97c128f3d0"), "6b78025d-5cdf-4dcd-ac8a-035a959bf57e", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Tammsaare tee" },
                    { new Guid("f7067b87-3cf3-4b90-9ad5-74f77c189f92"), "e7505307-733e-459a-97cd-415728cc6157", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "somevalue" },
                    { new Guid("dab32c86-d2ee-4562-b38c-6087df5dc340"), "0787dddf-06dc-41b2-a2a5-1bc5c1cf691f", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Bob" },
                    { new Guid("c4ff4973-a7b0-4edd-92b2-d9cb34761f77"), "b67f7dfc-0ecb-49ba-bcd8-adfb34c87f20", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Oak" },
                    { new Guid("daebc6f7-9a65-4682-8c07-165d42d8c75f"), "11be5de9-934a-4f43-88ba-3c33b7f483a7", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "bob@gmail.com" },
                    { new Guid("7e715486-4af2-4c3e-bf72-bb107afc8e78"), "1f928e7b-eb87-4e77-8d67-8956ed6d9f1f", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Ehitajate Tee" },
                    { new Guid("b1209055-b7bf-4762-8957-aea91c815119"), "da1b48b3-7051-463d-a911-2d293a7f6626", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "somevalue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
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
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
