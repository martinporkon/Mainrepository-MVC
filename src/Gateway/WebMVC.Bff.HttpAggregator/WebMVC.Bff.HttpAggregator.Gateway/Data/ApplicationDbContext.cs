using Microsoft.EntityFrameworkCore;
using WebMVC.Bff.HttpAggregator.Infra;
using WebMVC.Bff.HttpAggregator.Infra.DbContexts;

namespace WebMVC.Bff.HttpAggregator.Gateway.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BffDbContext.InitializeTables(builder);
            FileDbContext.InitializeTables(builder);
        }
    }
}