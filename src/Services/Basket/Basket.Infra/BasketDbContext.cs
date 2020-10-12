using Basket.Data.BasketOfProducts;
using Basket.Data.Baskets;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infra
{
    public class BasketDbContext : DbContext
    {
        public DbSet<BasketData> Baskets { get; set; }
        public DbSet<BasketOfProductsData> BasketOfProducts { get; set; }
        public BasketDbContext(DbContextOptions<BasketDbContext> options)
            : base(options) { }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<BasketOfProductsData>().ToTable(nameof(BasketOfProducts))
                .HasKey(x => new { x.BasketId, x.ProductOfPartyId });
            builder.Entity<BasketData>().ToTable(nameof(Baskets));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}