using Basket.Infra;
using CommonTests.InfraTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Infra;
using System.Linq;

namespace Basket.Tests.Infra
{
    [TestClass]
    public class OrderDbInitializerTests : DbInitializerTests<OrderDbContext>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(OrderDbInitializer);
            db = new OrderDbContext(options);

            removeAll(db.Orders);
        }

        [TestMethod]
        public void InitializeTest()
        {
            OrderDbInitializer.Initialize(db);
            Assert.AreEqual(10, db.Orders.Count());
        }
    }
}
