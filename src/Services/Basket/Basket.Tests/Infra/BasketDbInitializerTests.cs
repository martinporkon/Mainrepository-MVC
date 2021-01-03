using System.Linq;
using Basket.Infra;
using CommonTests.InfraTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basket.Tests.Infra
{
    [TestClass]
    public class BasketDbinitializerTests : DbInitializerTests<BasketDbContext>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(BasketDbInitializer);
            db = new BasketDbContext(options);

            removeAll(db.Baskets);
            removeAll(db.BasketOfProducts);

        }

        [TestMethod]
        public void InitializeTest()
        {
            BasketDbInitializer.Initialize(db);
            Assert.AreEqual(100, db.BasketOfProducts.Count());
            Assert.AreEqual(10, db.Baskets.Count());
        }
    }
}
