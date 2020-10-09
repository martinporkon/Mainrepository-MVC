using System;
using System.Collections.Generic;
using System.Text;
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
            builder.ApplyConfiguration(new ShipMethodsOfPartyEntityTypeConfiguration());
            builder.ApplyConfiguration(new ShipMethodDataEntityTypeConfiguration());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}