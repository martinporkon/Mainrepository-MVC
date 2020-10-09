using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Data.Addresses;

namespace Order.Infra.Configuration.Address
{
    internal class AddressDataEntityTypeConfiguration : IEntityTypeConfiguration<AddressData>
    {
        public void Configure(EntityTypeBuilder<AddressData> builder)
        {
            builder.ToTable("Addresses");
        }
    }
}