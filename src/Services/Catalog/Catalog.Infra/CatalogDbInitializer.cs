using Aids.Random;
using Catalog.Data.Catalog;
using Catalog.Data.CatalogedProducts;
using Catalog.Data.CatalogEntries;
using Catalog.Data.Price;
using Catalog.Data.Product;
using Catalog.Data.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Infra
{
    public class CatalogDbInitializer
    {
        internal static DateTime validFromMinimum = new DateTime(2019, 3, 1, 7, 0, 0);
        internal static DateTime validFromMaximum = DateTime.Now;

        internal static DateTime validToMinimum = DateTime.Now;
        internal static DateTime validToMaximum = new DateTime(2021, 3, 1, 7, 0, 0);

        internal static int randomDataGenerationAmount = 10;

        internal static List<UserProfileData> userProfiles => new List<UserProfileData>
        {
        new UserProfileData{
            Id = Guid.NewGuid(),
            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
            SubscriptionLevel = "Basic",
            SelectedParty = "Walmart"},

        new UserProfileData(){
            Id = Guid.NewGuid(),
            Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
            SubscriptionLevel = "FreeUser",
            SelectedParty = "Costco Wholesale"}
        };

        internal static List<CatalogData> catalogs => new List<CatalogData>
        {
        new CatalogData{
            Id = "0",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Products Catalog",
            Description = "This catalog contains all products" },

        new CatalogData{
            Id = "1",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Service Catalog",
            Description = "This catalog contains all services" },
        new CatalogData{
            Id = "2",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Archived Catalog",
            Description = "This catalog contains all products that are no longer on sale" },
        };

        internal static List<CatalogedProductData> catalogedProducts => new List<CatalogedProductData>
        {
            new CatalogedProductData{
                Id = "0",
                CatalogEntryId= "0",
                ProductTypeId= "0",
                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)}
        };
        internal static List<CatalogEntryData> catalogEntries => new List<CatalogEntryData>
        {
            new CatalogEntryData{
                Id= "0",
                CatalogId="0",
                CategoryId="0",
                Description= "Lisatud Yrgeni poolt",
                Name = "MIngi nimi",
                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)}
        };

        internal static List<ProductCategoryData> productCategories => new List<ProductCategoryData>
        {
        new ProductCategoryData{
            Id = "0",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Puuviljad",
            Description = "Värsked puuviljad üle kogu maailma" },
        

        new ProductCategoryData{
            Id = "1",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Lihatooted",
            Description = "Lai valik erinevaid lihatooteid" },

        new ProductCategoryData{
            Id = "3",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Õunad",
            Description = "Õun kuulub puuviljade hulka",
            BaseCategoryId = "0" },

        new ProductCategoryData{
            Id = "4",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Prinid",
            Description = "Pirn kuulub puuviljade hulka",
            BaseCategoryId = "0" },

        new ProductCategoryData{
            Id = "5",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Veiseliha",
            Description = "Veiseliha on lihatoodete alamkategooria",
            BaseCategoryId = "1" },

         new ProductCategoryData{
            Id = "6",
            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
            Name = "Sealiha",
            Description = "Sealiha on lihatoodete alamkategooria",
            BaseCategoryId = "1" },
        };
        


        //internal static List<PartyData> parties => new List<PartyData>{
        //    //TODO: Initialize predefined party data
        //    new PartyData { Id ="0", ValidFrom =  GetRandom.DateTime(validFromMinimum, validFromMaximum),
        //        ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum), Name="Prisma Lasnamäe", AddressId = "1",
        //        Latitude ="59.44226761",Longitude="24.8383031", Hours = "08.00-23.00", Organization= "Prisma Peremarketid"},

        //    new PartyData { Id = "1", ValidFrom =  GetRandom.DateTime(validFromMinimum, validFromMaximum),
        //        ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum), Name="Prisma Mustamäe", AddressId = "2",
        //        Latitude ="59.410379",Longitude="24.68301", Hours = "24h", Organization= "Prisma Peremarketid"},

        //    new PartyData { Id ="2", ValidFrom =  GetRandom.DateTime(validFromMinimum, validFromMaximum),
        //        ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum), Name="Prisma Rocca Al Mare", AddressId = "3",
        //        Latitude ="59.410379",Longitude="24.68301", Hours = "24h", Organization= "Prisma Peremarketid"},
        //};

        internal static List<PriceData> prices = new List<PriceData> { };
        internal static void generatePrices()
        {
            for (int i = 0; i < randomDataGenerationAmount; i++)
            {
                prices.Add(new PriceData { Id = i.ToString(), ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum), ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum), Amount = GetRandom.Decimal(0, 30), CurrencyId = i.ToString(), ProductInstanceId = GetRandom.Int8(0,8).ToString() });
            }
        }

        //internal static List<ProductsOfPartyData> productsOfParties = new List<ProductsOfPartyData> { };
        //internal static void generateProductOfParties()
        //{
        //    for (int i = 0; i < products.Count(); i++)
        //    {
        //        for (int k = 0; k < parties.Count(); k++)
        //        {

        //            productsOfParties.Add(new ProductsOfPartyData
        //            {
        //                Id = Guid.NewGuid().ToString(),
        //                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
        //                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
        //                ProductId = i.ToString(),
        //                PartyId = k.ToString(),
        //                PriceId = GetRandom.Int32(0, (sbyte)prices.Count()).ToString()
        //            });
        //        }

        //    }
        //}
        internal static List<CountryOfOriginData> countriesOfOrigin => new List<CountryOfOriginData>
        {
            new CountryOfOriginData{
                Id = "EST",
                Description = "EE",
                Name = "Eesti",
                OfficialName= "Estonia",
                NativeName="Eesti",
                IsIsoCOuntry = true,
                NumericCode = "70",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),

            },
        };
        internal static List<ProductTypeData> productTypes => new List<ProductTypeData>
        {
            new ProductTypeData{ 
                Id = "0",
                ProductKind = ProductKind.Product,
                Name = "Piim 2,5%",
                BrandId = "0",
                Amount = 1,
                UnitId= "0",
                CountryOfOriginId = "EST",
                BarCode = "4740125000108",
                Description = "Hea Eestimaine piim",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),            
            },
             new ProductTypeData{
                Id = "1",
                ProductKind = ProductKind.Product,
                Name = "Piim 2,5%",
                BrandId = "1",
                Amount = 1,
                UnitId= "0",
                CountryOfOriginId = "EST",
                BarCode = "4740036000013",
                Description = "D-vitamiiniga rikastatud piim",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),
            },
             new ProductTypeData{
                Id = "2",
                ProductKind = ProductKind.Product,
                Name = "Latte Piim 2,5%",
                BrandId = "1",
                Amount = 1,
                UnitId= "0",
                CountryOfOriginId = "EST",
                BarCode = "4740036009122",
                Description = "Piim parimate latte-de valmistamiseks",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),
            },
              new ProductTypeData{
                Id = "3",
                ProductKind = ProductKind.Product,
                Name = "Kodune hakkliha",
                BrandId = "2",
                Amount = 500,
                UnitId= "1",
                CountryOfOriginId = "EST",
                BarCode = "4740003003771",
                Description = "Säilitamine: +0…+2 °C. Enne tarvitamist kuumutada sisetemperatuurini vähemalt 71 °C.",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),
            },
              new ProductTypeData{
                Id = "4",
                ProductKind = ProductKind.Product,
                Name = "Kodune hakkliha",
                BrandId = "2",
                Amount = 450,
                UnitId= "1",
                CountryOfOriginId = "EST",
                BarCode = "	4740003002446",
                Description = "Mahlakas hakkliha eestimaisest sea- ja veiselihast. ",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),
            },
              new ProductTypeData{
                Id = "5",
                ProductKind = ProductKind.Product,
                Name = "Kodune hakkliha",
                BrandId = "3",
                Amount = 500,
                UnitId= "1",
                CountryOfOriginId = "EST",
                BarCode = "4740171075518",
                Description = "Säilitamine: +0…+2 °C. Enne tarvitamist kuumtöödelda.",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),
            },
              new ProductTypeData{
                Id = "6",
                ProductKind = ProductKind.Service,
                Name = "Kulleriga kohaletoimetamine",
                BrandId = "4",
                Amount = 1,
                UnitId= "2",
                CountryOfOriginId = "",
                BarCode = "",
                Description = "Kuller toimetab tellimuse teie aadressile",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),
                
            },
        };
        internal static List<ProductInstanceData> productInstances => new List<ProductInstanceData>{
            new ProductInstanceData { 
                Id="0",
                ProductTypeId= "5",
                Amount = 1,
                UnitId = "2",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)},
             new ProductInstanceData {
                Id="1",
                ProductTypeId= "4",
                Amount = 3,
                UnitId = "2",
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)},
              new ProductInstanceData {
                Id="2",
                ProductTypeId= "6",
                Amount = 1,
                UnitId = "2",
                DeliveredFrom=GetRandom.DateTime(validFromMinimum, validFromMaximum),
                DeliveredTo=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ScheduledFrom= GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ScheduledTo = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                DeliveryStatus= Data.Services.DeliveryStatus.Scheduled,
                ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)},
        };

        //internal static List<SubCategoryData> subcategories = new List<SubCategoryData> { };
        //internal static void generateSubCategories()
        //{
        //    //TODO category id oleks korrektne
        //    for (int i = 0; i < Enum.GetNames(typeof(SubCategories)).Length; i++)
        //    {
        //        subcategories.Add(new SubCategoryData
        //        {
        //            Id = i.ToString(),
        //            CategoryId = GetRandom.Enum<Categories>().ToString(),
        //            Name = ((SubCategories)i).ToString(),
        //            ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
        //            ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)
        //        });
        //    }
        //}
        internal static List<BrandData> brands => new List<BrandData>{
            new BrandData {
                Id="0",
                Name = "Alma",
                Description= "Kirjeldus Alma kohta",
                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)},
             new BrandData {
                Id="1",
                Name = "Tere",
                Description= "Kirjeldus Tere kohta",
                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)},
             new BrandData {
                Id="2",
                Name = "Rakvere LK",
                Description= "Kirjeldus Rakvere LK kohta",
                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)},
             new BrandData {
                Id="3",
                Name = "Maks ja Moorits",
                Description= "Kirjeldus Maks ja Moorits kohta",
                ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)},
            };



        private static bool initializeUserProfiles(CatalogDbContext db)
        {
            if (db.UserProfiles.Count() != 0) return false;
            db.UserProfiles.AddRange(userProfiles);
            db.SaveChanges();
            return true;
        }
        private static bool initializeCatalogs(CatalogDbContext db)
        {
            if (db.Catalogs.Count() != 0) return false;
            db.Catalogs.AddRange(catalogs);
            db.SaveChanges();
            return true;
        }
        private static bool initializeCatalogedProducts(CatalogDbContext db)
        {
            if (db.CatalogedProducts.Count() != 0) return false;
            db.CatalogedProducts.AddRange(catalogedProducts);
            db.SaveChanges();
            return true;
        }
        private static bool initializeCatalogEntries(CatalogDbContext db)
        {
            if (db.CatalogEntries.Count() != 0) return false;
            db.CatalogEntries.AddRange(catalogEntries);
            db.SaveChanges();
            return true;
        }

        private static bool initializeProductCategories(CatalogDbContext db)
        {
            if (db.ProductCategories.Count() != 0) return false;
            db.ProductCategories.AddRange(productCategories);
            db.SaveChanges();
            return true;
        }


        private static bool initializePrices(CatalogDbContext db)
        {

            if (db.Prices.Count() != 0) return false;
            generatePrices();
            db.Prices.AddRange(prices);
            db.SaveChanges();
            return true;
        }
        private static bool initializeProductTypes(CatalogDbContext db)
        {

            if (db.ProductTypes.Count() != 0) return false;
            db.ProductTypes.AddRange(productTypes);
            db.SaveChanges();
            return true;
        }
        private static bool initializeProductInstances(CatalogDbContext db)
        {

            if (db.ProductInstances.Count() != 0) return false;
            db.ProductInstances.AddRange(productInstances);
            db.SaveChanges();
            return true;
        }

        private static bool initializeCountriesOfOrigin(CatalogDbContext db)
        {
            if (db.CountriesOfOrigin.Count() != 0) return false;
            db.CountriesOfOrigin.AddRange(countriesOfOrigin);
            db.SaveChanges();
            return true;
        }
        private static bool initializeBrands(CatalogDbContext db)
        {
            if (db.Brands.Count() != 0) return false;
            db.Brands.AddRange(brands);
            db.SaveChanges();
            return true;
        }

        //private static bool initializeProducts(CatalogDbContext db)
        //{
        //    if (db.Products.Count() != 0) return false;
        //    db.Products.AddRange(products);
        //    db.SaveChanges();
        //    return true;
        //}



        public static bool Initialize(CatalogDbContext db)
        {
            //order matters
            initializeUserProfiles(db);
            initializeCatalogs(db);
            initializeCatalogedProducts(db);
            initializeCatalogEntries(db);
            initializeProductTypes(db);
            initializeProductInstances(db);
            initializeCountriesOfOrigin(db);
            initializeBrands(db);
            initializeProductCategories(db);
            initializePrices(db);
           
            return true;
        }

    }
}
