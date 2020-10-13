using Identity.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Sooduskorv.IDP.Data
{
    public class IdentityApplicationDbContext : DbContext
    {

        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityDbContext.InitializeTables(builder);
        }
    }
}