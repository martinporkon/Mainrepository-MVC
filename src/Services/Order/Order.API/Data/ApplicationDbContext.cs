using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Infra;

namespace Order.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        internal void InitializeTables(ModelBuilder builder)
        {
            AddressDbContext.InitializeTables(builder);
            /*ShippingDbContext.InitializeTables(builder);*/
            OrderDbContext.InitializeTables(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
    }
}