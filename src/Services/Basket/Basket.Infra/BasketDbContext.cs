using Basket.Data.BasketOfProducts;
using Basket.Data.Baskets;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infra
{
    public class BasketDbContext : DbContext
    {
        public DbSet<BasketData> Baskets { get; set; }
        public DbSet<BasketOfProductsData> BasketOfProducts { get; set; }
        
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null) return;
            modelBuilder.Entity<BasketData>().ToTable(nameof(Baskets));
            modelBuilder.Entity<BasketOfProductsData>().ToTable(nameof(BasketOfProducts))
               .HasKey(x => new { x.BasketId, x.ProductOfPartyId });
        }
    }
}