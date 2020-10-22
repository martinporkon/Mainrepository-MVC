using Microsoft.EntityFrameworkCore;
using Order.Data.Orders;
using Order.Infra.Configuration.Order;

namespace Order.Infra
{
    public class OrderDbContext : DbContext
    {
        public DbSet<OrderData> Orders { get; set; }
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderData>().ToTable(nameof(Orders));
        }
    }
}