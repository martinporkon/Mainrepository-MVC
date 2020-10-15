using Basket.Data.BasketOfProducts;
using Basket.Data.Baskets;
using Basket.Infra;
using CommonTests.InfraTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Tests.Infra
{
    [TestClass]
    public class BasketDbContextTests : DbContextTests<BasketDbContext, DbContext>
    {
        private ModelBuilder modelBuilder;
        private class testClass : BasketDbContext
        {

            public testClass(DbContextOptions<BasketDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<BasketDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new BasketDbContext(options);
            InitializeTablesTest();
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            BasketDbContext.InitializeTables(null);
            var o = new testClass(options);
            modelBuilder = o.RunOnModelCreating();
            BasketDbContext.InitializeTables(modelBuilder);

        }
        [TestMethod] public void BasketOfProductsTest() => testHasDbSet<BasketOfProductsData>(modelBuilder, x => x.BasketId, x => x.ProductOfPartyId);

        [TestMethod] public void BasketsTest() => testHasDbSet<BasketData>(modelBuilder);
    }
}
