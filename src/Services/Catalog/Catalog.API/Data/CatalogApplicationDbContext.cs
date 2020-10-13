using Catalog.Infra;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class CatalogApplicationDbContext : DbContext
    {
        public CatalogApplicationDbContext(DbContextOptions<CatalogApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CatalogDbContext.InitializeTables(builder);
        }
    }
}