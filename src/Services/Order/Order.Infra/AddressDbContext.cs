using Microsoft.EntityFrameworkCore;
using Order.Data.Addresses;
using Order.Data.AddressOfCustomer;
using Order.Infra.Configuration.Address;

namespace Order.Infra
{
    public class AddressDbContext : DbContext
    {
        public DbSet<AddressOfCustomerData> AddressOfCustomers { get; set; }
        public DbSet<AddressData> Addresses { get; set; }

        public AddressDbContext(DbContextOptions<AddressDbContext> options)
            : base(options) { }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressDataEntityTypeConfiguration());
            builder.ApplyConfiguration(new AddressOfCustomerDataEntityTypeConfiguration());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}