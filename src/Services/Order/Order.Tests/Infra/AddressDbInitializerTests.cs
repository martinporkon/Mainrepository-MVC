using Basket.Infra;
using CommonTests.InfraTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Infra;
using System.Linq;

namespace Basket.Tests.Infra
{
    [TestClass]
    public class AddressDbInitializerTests : DbInitializerTests<AddressDbContext>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AddressDbInitializer);
            db = new AddressDbContext(options);

            removeAll(db.Addresses);
            removeAll(db.AddressOfCustomers);
            removeAll(db.AddressOfParties);
        }

        [TestMethod]
        public void InitializeTest()
        {
            AddressDbInitializer.Initialize(db);
            Assert.AreEqual(10, db.Addresses.Count());
            Assert.AreEqual(10, db.AddressOfCustomers.Count());
            Assert.AreEqual(10, db.AddressOfParties.Count());
        }
    }
}
