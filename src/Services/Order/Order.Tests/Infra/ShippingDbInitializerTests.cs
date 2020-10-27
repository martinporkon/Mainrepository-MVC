using System.Linq;
using CommonTests.InfraTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Infra;

namespace Order.Tests.Infra
{
    [TestClass]
    public class ShippingDbInitializerTests : DbInitializerTests<ShippingDbContext>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ShippingDbInitializer);
            db = new ShippingDbContext(options);
            
            removeAll(db.ShipMethods);
            removeAll(db.ShipMethodsOfParties);
        }

        [TestMethod]
        public void InitializeTest()
        {
            ShippingDbInitializer.Initialize(db);
            Assert.AreEqual(4, db.ShipMethods.Count());
            Assert.AreEqual(12, db.ShipMethodsOfParties.Count());
            
        }
    }
}
