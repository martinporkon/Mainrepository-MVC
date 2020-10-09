using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Data.ShipMethods;

namespace Order.Infra.Configuration.Shipping
{
    internal class ShipMethodDataEntityTypeConfiguration : IEntityTypeConfiguration<ShipMethodData>
    {
        public void Configure(EntityTypeBuilder<ShipMethodData> builder)
        {
            builder.ToTable("ShipMethods");
        }
    }
}