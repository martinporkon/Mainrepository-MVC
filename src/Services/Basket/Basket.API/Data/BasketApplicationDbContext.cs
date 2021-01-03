using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data
{
    public class BasketApplicationDbContext : DbContext
    {
        public BasketApplicationDbContext(DbContextOptions<BasketApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BasketDbContext.InitializeTables(builder);
        }
        
    }
}