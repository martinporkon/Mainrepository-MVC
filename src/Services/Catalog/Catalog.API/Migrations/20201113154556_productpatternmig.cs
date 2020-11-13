using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Migrations
{
    public partial class productpatternmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogedProducts",
                columns: table => new
                {
                    CatalogEntryId = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogedProducts", x => new { x.CatalogEntryId, x.ProductTypeId });
                });

            migrationBuilder.CreateTable(
                name: "CatalogEntries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CatalogId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
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
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureInstances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FeatureTypeId = table.Column<string>(nullable: true),
                    Value_UnitOrCurrencyId = table.Column<string>(nullable: true),
                    Value_Value = table.Column<string>(nullable: true),
                    Value_ValueType = table.Column<int>(nullable: true),
                    Value_From = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureInstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductTypeId = table.Column<string>(nullable: true),
                    IsMandatory = table.Column<bool>(nullable: false),
                    NumericCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossibleFeatureValues",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FeatureTypeId = table.Column<string>(nullable: true),
                    Value_UnitOrCurrencyId = table.Column<string>(nullable: true),
                    Value_Value = table.Column<string>(nullable: true),
                    Value_ValueType = table.Column<int>(nullable: true),
                    Value_From = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleFeatureValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(16,4)", nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    ProductTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BaseCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductTypeId = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ProductKind = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    UnitId = table.Column<string>(nullable: true),
                    ScheduledFrom = table.Column<DateTime>(nullable: false),
                    ScheduledTo = table.Column<DateTime>(nullable: false),
                    DeliveredFrom = table.Column<DateTime>(nullable: false),
                    DeliveredTo = table.Column<DateTime>(nullable: false),
                    DeliveryStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductKind = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    UnitId = table.Column<string>(nullable: true),
                    PeriodOfOperationFrom = table.Column<DateTime>(nullable: true),
                    PeriodOfOperationTo = table.Column<DateTime>(nullable: true),
                    BrandId = table.Column<string>(nullable: true),
                    CountryOfOriginId = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 50, nullable: false),
                    SubscriptionLevel = table.Column<string>(maxLength: 250, nullable: false),
                    SelectedParty = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogedProducts");

            migrationBuilder.DropTable(
                name: "CatalogEntries");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "FeatureInstances");

            migrationBuilder.DropTable(
                name: "FeatureTypes");

            migrationBuilder.DropTable(
                name: "PossibleFeatureValues");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductInstances");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
