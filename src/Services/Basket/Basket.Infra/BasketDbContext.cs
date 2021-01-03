using Basket.Data.BasketOfProducts;
using Basket.Data.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Basket.Infra
{
    public class BasketDbContext : DbContext
    {
        public DbSet<BasketData> Baskets { get; set; }
        public DbSet<BasketOfProductData> BasketOfProducts { get; set; }

        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options) { }

        public static readonly ILoggerFactory Logger =
            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information);
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null) return;
            modelBuilder.Entity<BasketData>().ToTable(nameof(Baskets));
            modelBuilder.Entity<BasketOfProductData>().ToTable(nameof(BasketOfProducts))
               .HasKey(x => new { x.BasketId, x.ProductOfPartyId });
        }
    }
}