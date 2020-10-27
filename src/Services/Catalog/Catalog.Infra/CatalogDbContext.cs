using Catalog.Data.Categories;
using Catalog.Data.Parties;
using Catalog.Data.Prices;
using Catalog.Data.ProductOfParty;
using Catalog.Data.Products;
using Catalog.Data.SubCategories;
using Catalog.Data.UserProfiles;
using Microsoft.EntityFrameworkCore;


namespace Catalog.Infra
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<CategoryData> Categories { get; set; }
        public DbSet<PartyData> Parties { get; set; }
        public DbSet<PriceData> Prices { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductsOfPartyData> ProductsOfParties { get; set; }
        public DbSet<SubCategoryData> SubCategories { get; set; }
        public DbSet<UserProfileData> UserProfiles { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfileData>().ToTable(nameof(UserProfiles));
            modelBuilder.Entity<CategoryData>().ToTable(nameof(Categories));
            modelBuilder.Entity<PartyData>().ToTable(nameof(Parties));
            modelBuilder.Entity<PriceData>().ToTable(nameof(Prices)).Property(x => x.Price)
                .HasColumnType("decimal(16,2)");
            modelBuilder.Entity<ProductData>().ToTable(nameof(Products));
            modelBuilder.Entity<ProductsOfPartyData>().ToTable(nameof(ProductsOfParties)).HasKey(x => new { x.ProductId, x.PartyId });              
            modelBuilder.Entity<SubCategoryData>().ToTable(nameof(SubCategories));
        }
    }
}
