using Catalog.Data.Catalog;
using Catalog.Data.CatalogedProducts;
using Catalog.Data.CatalogEntries;
using Catalog.Data.Price;
using Catalog.Data.Product;
using Catalog.Data.ProductFeature;
using Catalog.Data.UserProfiles;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<CountryOfOriginData> CountriesOfOrigin { get; set; }
        public DbSet<BrandData> Brands { get; set; }
        public DbSet<ProductInstanceData> ProductInstances { get; set; }
        public DbSet<ProductTypeData> ProductTypes { get; set; }
        public DbSet<FeatureInstanceData> FeatureInstances { get; set; }
        public DbSet<FeatureTypeData> FeatureTypes { get; set; }
        public DbSet<PossibleFeatureValueData> PossibleFeatureValues { get; set; }
        public DbSet<CatalogedProductData> CatalogedProducts { get; set; }
        public DbSet<CatalogEntryData> CatalogEntries { get; set; }
        public DbSet<ProductCategoryData> ProductCategories { get; set; }
        public DbSet<CatalogData> Catalogs { get; set; }
        public DbSet<PriceData> Prices { get; set; }
        public DbSet<UserProfileData> UserProfiles { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<CountryOfOriginData>().ToTable(nameof(CountriesOfOrigin));
            builder.Entity<BrandData>().ToTable(nameof(Brands));
            builder.Entity<UserProfileData>().ToTable(nameof(UserProfiles));
            builder.Entity<ProductInstanceData>().ToTable(nameof(ProductInstances));
            builder.Entity<ProductTypeData>().ToTable(nameof(ProductTypes));
            builder.Entity<FeatureTypeData>().ToTable(nameof(FeatureTypes));
            builder.Entity<PossibleFeatureValueData>().ToTable(nameof(PossibleFeatureValues)).OwnsOne(
                    x => x.Value);
            builder.Entity<FeatureInstanceData>().ToTable(nameof(FeatureInstances)).OwnsOne(
                x => x.Value);
            builder.Entity<CatalogedProductData>().ToTable(nameof(CatalogedProducts))
                .HasKey(x => new { x.CatalogEntryId, x.ProductTypeId });
            builder.Entity<CatalogEntryData>().ToTable(nameof(CatalogEntries));
            builder.Entity<ProductCategoryData>().ToTable(nameof(ProductCategories));
            builder.Entity<CatalogData>().ToTable(nameof(Catalogs));
            builder.Entity<PriceData>().ToTable(nameof(Prices))
                .Property(x => x.Amount)
                .HasColumnType("decimal(16,4)");
        }
    }
}