using Microsoft.EntityFrameworkCore;
using WebMVC.Bff.HttpAggregator.Data.FileExtensions;
using WebMVC.Bff.HttpAggregator.Data.Signatures;

namespace WebMVC.Bff.HttpAggregator.Infra.DbContexts
{
    public class FileDbContext : DbContext
    {
        public DbSet<FileExtensionData> FileExtensions { get; set; }
        public DbSet<FileSignatureData> FileSignatures { get; set; }
        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<FileExtensionData>().ToTable(nameof(FileExtensions)).HasKey(x => new { x.Id });
            builder.Entity<FileSignatureData>().ToTable(nameof(FileSignatures)).HasKey(x => new { x.Id });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}