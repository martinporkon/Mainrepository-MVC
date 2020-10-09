using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Data.AddressOfCustomer;

namespace Order.Infra.Configuration.Address
{
    internal class AddressOfCustomerDataEntityTypeConfiguration : IEntityTypeConfiguration<AddressOfCustomerData>
    {
        public void Configure(EntityTypeBuilder<AddressOfCustomerData> builder)
        {
            builder.ToTable("AddressOfCustomers")
                .HasKey(x => new { x.AddressId, x.CustomerId });
        }
    }
}