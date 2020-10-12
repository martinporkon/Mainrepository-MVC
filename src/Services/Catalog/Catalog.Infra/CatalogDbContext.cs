using Catalog.Data.Categories;
using Catalog.Data.Parties;
using Catalog.Data.Prices;
using Catalog.Data.ProductOfParty;
using Catalog.Data.Products;
using Catalog.Data.SubCategories;
using Microsoft.EntityFrameworkCore;
using System;
using Catalog.Data.UserProfiles;

namespace Catalog.Infra
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<CategoryData> Categories { get; set; }
        public DbSet<PartyData> Parties { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PriceData> Prices { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductsOfPartyData> ProductsOfParties { get; set; }
        public DbSet<SubCategoryData> SubCategories { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryData>().ToTable(nameof(Categories));
            modelBuilder.Entity<PartyData>().ToTable(nameof(Parties));
            modelBuilder.Entity<PriceData>().ToTable(nameof(Prices)).Property(x => x.Price)
                .HasColumnType("decimal(16,2)");
            modelBuilder.Entity<ProductData>().ToTable(nameof(Products));
            modelBuilder.Entity<ProductsOfPartyData>().ToTable(nameof(ProductsOfParties)).HasKey(x => new { x.ProductId, x.PartyId });
            modelBuilder.Entity<UserProfile>().ToTable(nameof(UserProfiles))
                .HasData(
                    new UserProfile()
                    {
                        Id = Guid.NewGuid(),
                        Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                        SubscriptionLevel = "Basic",
                        SelectedParty = "Walmart",
                    },
                    new UserProfile()
                    {
                        Id = Guid.NewGuid(),
                        Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                        SubscriptionLevel = "FreeUser",
                        SelectedParty = "Costco Wholesale",
                    });
            modelBuilder.Entity<SubCategoryData>().ToTable(nameof(SubCategories));
        }
    }
}
