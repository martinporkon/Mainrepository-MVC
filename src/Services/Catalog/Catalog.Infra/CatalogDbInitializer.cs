using Aids.Random;
using Catalog.Data.Catalog;
using Catalog.Data.Price;
using Catalog.Data.Product;
using Catalog.Data.UserProfiles;
using System;
using System.Collections.Generic;

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

        internal static List<CatalogData> Catalogs => new List<CatalogData>
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
                prices.Add(new PriceData { Id = i.ToString(), ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum), ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum), Amount = GetRandom.Decimal(0, 30), CurrencyId = i.ToString(), ProductTypeId = "1" });
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

        internal static List<ProductTypeData> productTypes => new List<ProductTypeData>
        {
            new ProductTypeData{ Id ="0", BrandId = "0", ProductKind = ProductKind.Product,
                CountryOfOriginId = "0", Description= "Hea eestimaine piim",
                Name = "Piim 2,5% ",  ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum), Amount=400  },

            //new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Tere", CategoryId = Categories.Piimatooted.ToString(),
            //    Code= "4740036000013",CountryOfOrigin = "Eesti", Composition = "1", Description= "-vitamiiniga rikastatud piimad on sündinud soovist pakkuda meie tarbijatele aastaringselt päikest.",
            //    Name = "Piim 2,5 %", Image = "", Measure = "L", SubCategoryId= SubCategories.Piimad.ToString(),
            //    Supplier = "Tere AS", Type= "Piimatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum), Amount="500"  },

            //new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Tere", CategoryId = Categories.Piimatooted.ToString(),
            //    Code= "	4740036009122",CountryOfOrigin = "Eesti", Composition = "1", Description= "Eestlastele kõige harjumuspärasema rasvaprotsendiga kõrgkuumutatud piim. ",
            //    Name = "Latte piim 2,5%", Image = "", Measure = "L", SubCategoryId= SubCategories.Piimad.ToString(),
            //    Supplier = "Tere AS", Type= "Piimatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum),  Amount="400"  },

            //new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Rakvere", CategoryId = Categories.Lihatooted.ToString(),
            //    Code= "4740003003771", CountryOfOrigin = "Eesti", Composition = "500",
            //    Description= "Säilitamine: +0…+2 °C. Enne tarvitamist kuumutada sisetemperatuurini vähemalt 71 °C.",
            //    Name = "Kodune hakkliha", Image = "", Measure = "g", SubCategoryId= SubCategories.Hakkliha.ToString(),
            //    Supplier = "HKSCAN ESTONIA AS", Type= "Lihatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)  },

            //new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Eesti Juust", CategoryId = Categories.Piimatooted.ToString(),
            //    Code= "4740572003165", CountryOfOrigin = "Eesti", Composition = "400", Description= "Silindriline hollandi tüüpi laabijuust.",
            //    Name = "Traditsiooniline Eesti juust", Image = "", Measure = "g", SubCategoryId= SubCategories.kodujuustud.ToString(),
            //    Supplier = "ESTOVER PIIMATÖÖSTUS OÜ", Type= "Piimatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)  },

            //new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Rannarootsi", CategoryId = Categories.Lihatooted.ToString(),
            //    Code= "4740215800304", CountryOfOrigin = "Eesti", Composition = "900", Description= "Madalal temperatuuril eelküpsetatud ribi, mis on mahedas marinaadis.",
            //    Name = "Kuldne grillribi eelküpsetatud", Image = "", Measure = "g", SubCategoryId= SubCategories.Sealiha.ToString(),
            //    Supplier = "MAAG KONSERVITÖÖSTUS AS", Type= "Lihatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)  },

            // new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Rakvere", CategoryId = Categories.Lihatooted.ToString(),
            //    Code= "4740003006741", CountryOfOrigin = "Eesti", Composition = "500", Description= "Kodumaine seakaelakarbonaad ja kergelt suitsune mustikamarinaad.",
            //    Name = "Mustika grill-liha", Image = "", Measure = "g", SubCategoryId= SubCategories.Sealiha.ToString(),
            //    Supplier = "HKSCAN ESTONIA AS", Type= "Lihatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)  },

            // new ProductData{ Id =Guid.NewGuid().ToString(), Brand = "Maks&Moorits", CategoryId = Categories.Lihatooted.ToString(),
            //    Code= "4740171081625", CountryOfOrigin = "Eesti", Composition = "600", Description= "Vana-hea klassikaline äädikamarinaadis sealihast šašlõkk (liha 90%).",
            //    Name = "Šašlõkk klassikalises marinaadis", Image = "", Measure = "g", SubCategoryId= SubCategories.Sealiha.ToString(),
            //    Supplier = "ATRIA EESTI AS", Type= "Lihatoode", ValidFrom=  GetRandom.DateTime(validFromMinimum, validFromMaximum),
            //    ValidTo =  GetRandom.DateTime(validToMinimum, validToMaximum)  },

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

        //private static bool initializeUserProfiles(CatalogDbContext db)
        //{
        //    if (db.UserProfiles.Count() != 0) return false;
        //    db.UserProfiles.AddRange(userProfiles);
        //    db.SaveChanges();
        //    return true;
        //}

        //private static bool initializeCategories(CatalogDbContext db)
        //{
        //    if (db.Categories.Count() != 0) return false;
        //    generateCategories();
        //    db.Categories.AddRange(categories);
        //    db.SaveChanges();
        //    return true;
        //}

        //private static bool initializeParties(CatalogDbContext db)
        //{
        //    if (db.Parties.Count() != 0) return false;
        //    db.Parties.AddRange(parties);
        //    db.SaveChanges();
        //    return true;
        //}

        //private static bool initializePrices(CatalogDbContext db)
        //{

        //    if (db.Prices.Count() != 0) return false;
        //    generatePrices();
        //    db.Prices.AddRange(prices);
        //    db.SaveChanges();
        //    return true;
        //}

        //private static bool initializeProductsOfParties(CatalogDbContext db)
        //{
        //    if (db.ProductsOfParties.Count() != 0) return false;
        //    generateProductOfParties();
        //    db.ProductsOfParties.AddRange(productsOfParties);
        //    db.SaveChanges();
        //    return true;
        //}

        //private static bool initializeProducts(CatalogDbContext db)
        //{
        //    if (db.Products.Count() != 0) return false;
        //    db.Products.AddRange(products);
        //    db.SaveChanges();
        //    return true;
        //}

        //private static bool initializeSubcategories(CatalogDbContext db)
        //{
        //    if (db.SubCategories.Count() != 0) return false;
        //    generateSubCategories();
        //    db.SubCategories.AddRange(subcategories);
        //    db.SaveChanges();
        //    return true;
        //}

        public static bool Initialize(CatalogDbContext db)
        {
            //order matters
            //initializeCatalogs(db);
            //initializeParties(db);
            //initializeProducts(db);
            //initializeSubcategories(db);
            //initializeCategories(db);
            //initializePrices(db);
            //initializeProductsOfParties(db);
            return true;
        }

    }
}
