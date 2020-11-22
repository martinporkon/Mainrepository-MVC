using Microsoft.EntityFrameworkCore;
using Order.Data.Addresses;
using Order.Data.AddressOfCustomer;
using Order.Data.AddressOfParty;

namespace Order.Infra
{
    public class AddressDbContext : DbContext
    {
        public DbSet<AddressOfCustomerData> AddressOfCustomers { get; set; }
        public DbSet<AddressOfPartyData> AddressOfParties { get; set; }
        public DbSet<AddressData> Addresses { get; set; }

        public AddressDbContext(DbContextOptions<AddressDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null) return;
            modelBuilder.Entity<AddressData>().ToTable(nameof(Addresses));
            /*modelBuilder.Entity<AddressOfCustomerData>().ToTable(nameof(AddressOfCustomers)).HasKey(x => new { x.AddressId, x.BuyerId });
            modelBuilder.Entity<AddressOfPartyData>().ToTable(nameof(AddressOfParties)).HasKey(x => new { x.AddressId, x.PartyId });*/
        }
    }
}