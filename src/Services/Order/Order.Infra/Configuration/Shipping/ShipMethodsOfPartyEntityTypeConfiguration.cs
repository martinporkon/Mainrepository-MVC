using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Data.ShipMethodOfParty;

namespace Order.Infra.Configuration.Shipping
{
    internal class ShipMethodsOfPartyEntityTypeConfiguration : IEntityTypeConfiguration<ShipMethodsOfPartyData>
    {
        public void Configure(EntityTypeBuilder<ShipMethodsOfPartyData> builder)
        {
            builder.ToTable("ShipMethodOfParties")
                .Property(x => new { x.MinimalOrderPrice, x.Price })
                .HasColumnType("decimal(16,4)");
        }
    }
}