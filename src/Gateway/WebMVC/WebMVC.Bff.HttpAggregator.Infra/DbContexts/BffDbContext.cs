using Microsoft.EntityFrameworkCore;
using WebMVC.Bff.HttpAggregator.Data.ImageInformations;
using WebMVC.Bff.HttpAggregator.Data.Resources;

namespace WebMVC.Bff.HttpAggregator.Infra
{
    public sealed class BffDbContext : DbContext
    {
        public DbSet<ResourceData> Resources { get; set; }
        public DbSet<ImageInformationData> ImageInformation { get; set; }

        public BffDbContext(DbContextOptions<BffDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceData>().ToTable(nameof(Resources)).HasKey(x => new { x.Id });
            modelBuilder.Entity<ImageInformationData>().ToTable(nameof(ImageInformation)).HasKey(x => new { x.Id });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
    }
}