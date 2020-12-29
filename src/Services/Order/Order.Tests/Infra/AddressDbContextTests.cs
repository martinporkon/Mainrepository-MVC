using CommonTests.InfraTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.Addresses;
using Order.Data.AddressOfCustomer;
using Order.Data.AddressOfParty;
using Order.Infra;

namespace Order.Tests.Infra
{
    [TestClass]
    public class AddressDbContextTests : DbContextTests<AddressDbContext, DbContext>
    {
        private ModelBuilder modelBuilder;
        private class testClass : AddressDbContext
        {

            public testClass(DbContextOptions<AddressDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<AddressDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new AddressDbContext(options);
            InitializeTablesTest();
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            AddressDbContext.InitializeTables(null);
            var o = new testClass(options);
            modelBuilder = o.RunOnModelCreating();
            AddressDbContext.InitializeTables(modelBuilder);

        }

        [TestMethod] public void AddressesTest() => testHasDbSet<AddressData>(modelBuilder);
        [TestMethod] public void AddressesOfCustomerTest() => testHasDbSet<AddressOfCustomerData>(modelBuilder, x => x.AddressId, x => x.BuyerId);
        [TestMethod] public void AddressesOfPartyTest() => testHasDbSet<AddressOfPartyData>(modelBuilder, x => x.AddressId, x => x.PartyId);
    }
}
