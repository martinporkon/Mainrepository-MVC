using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Data.Orders;

namespace Order.Infra.Configuration.Order
{
    public class OrderDataEntityTypeConfiguration : IEntityTypeConfiguration<OrderData>
    {
        public void Configure(EntityTypeBuilder<OrderData> builder)
        {
            builder.ToTable("Orders");
        }
    }
}