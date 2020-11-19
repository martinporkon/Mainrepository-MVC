using CommonTests.InfraTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.ShipMethodOfParty;
using Order.Data.ShipMethods;
using Order.Infra;

namespace Order.Tests.Infra
{
    [TestClass]
    public class ShippingDbContextTests : DbContextTests<ShippingDbContext, DbContext>
    {
        private class testClass : ShippingDbContext
        {

            public testClass(DbContextOptions<ShippingDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<ShippingDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new ShippingDbContext(options);
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            ShippingDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            ShippingDbContext.InitializeTables(builder);

            testEntity<ShipMethodsOfPartyData>(builder, x => x.ShipMethodId, x => x.PartyId);
            testEntity<ShipMethodData>(builder);
        }
        [TestMethod]
        public void ShipMethodsTest() =>
            isNullableProperty(obj, nameof(obj.ShipMethods), typeof(DbSet<ShipMethodData>));
        [TestMethod]
        public void ShipMethodsOfPartyTest() =>
            isNullableProperty(obj, nameof(obj.ShipMethodsOfParties), typeof(DbSet<ShipMethodsOfPartyData>));
    }
        
}
