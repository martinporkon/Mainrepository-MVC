using Basket.Data.BasketOfProducts;
using Basket.Data.Baskets;
using Basket.Infra;
using CommonTests.InfraTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.Orders;
using Order.Infra;

namespace Basket.Tests.Infra
{
    [TestClass]
    public class OrderDbContextTests : DbContextTests<OrderDbContext, DbContext>
    {
        private ModelBuilder modelBuilder;
        private class testClass : OrderDbContext
        {

            public testClass(DbContextOptions<OrderDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new OrderDbContext(options);
            InitializeTablesTest();
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            OrderDbContext.InitializeTables(null);
            var o = new testClass(options);
            modelBuilder = o.RunOnModelCreating();
            OrderDbContext.InitializeTables(modelBuilder);

        }

        [TestMethod] public void OrdersTest() => testHasDbSet<OrderData>(modelBuilder);
    }
}
