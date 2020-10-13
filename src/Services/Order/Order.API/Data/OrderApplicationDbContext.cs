using Microsoft.EntityFrameworkCore;
using Order.Infra;

namespace Order.API.Data
{
    public class OrderApplicationDbContext : DbContext
    {
        public OrderApplicationDbContext(DbContextOptions<OrderApplicationDbContext> options)
            : base(options) { }

        internal void InitializeTables(ModelBuilder builder)
        {
            AddressDbContext.InitializeTables(builder);
            ShippingDbContext.InitializeTables(builder);
            OrderDbContext.InitializeTables(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}