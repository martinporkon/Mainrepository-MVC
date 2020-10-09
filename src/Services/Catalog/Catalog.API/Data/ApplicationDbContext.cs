using System;
using Catalog.Data.Categories;
using Catalog.Data.Parties;
using Catalog.Data.Prices;
using Catalog.Data.ProductOfParty;
using Catalog.Data.Products;
using Catalog.Data.SubCategories;
using Catalog.Data.UserProfiles;
using Catalog.Infra.Quantity;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            QuantityDbContext.InitializeTables(builder);
        }
    }
}