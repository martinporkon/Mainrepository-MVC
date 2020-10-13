using Microsoft.EntityFrameworkCore;
using Order.Data.ShipMethodOfParty;
using Order.Data.ShipMethods;
using Order.Infra.Configuration.Shipping;

namespace Order.Infra
{
    public class ShippingDbContext : DbContext
    {
        public DbSet<ShipMethodData> ShipMethods { get; set; }
        public DbSet<ShipMethodsOfPartyData> ShipMethodsOfParties { get; set; }
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options)
            : base(options) { }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<ShipMethodData>().ToTable(nameof(ShipMethods));
            builder.Entity<ShipMethodsOfPartyData>().ToTable(nameof(ShipMethodsOfParties)).HasKey(x => new { x.PartyId, x.ShipMethodId });
            builder.Entity<ShipMethodsOfPartyData>().ToTable(nameof(ShipMethodsOfParties)).Property(x => x.Price)
                .HasColumnType("decimal(16,2)");
            builder.Entity<ShipMethodsOfPartyData>().ToTable(nameof(ShipMethodsOfParties)).Property(x => x.MinimalOrderPrice)
                .HasColumnType("decimal(16,2)");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}