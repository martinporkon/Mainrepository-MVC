using Basket.Infra;
using CommonTests.InfraTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            
            removeAll(db.BasketOfProducts);
            removeAll(db.Baskets);
        }

        [TestMethod]
        public void InitializeTest()
        {
            BasketDbInitializer.Initialize(db);
            Assert.AreEqual(90, db.BasketOfProducts.Count());
            Assert.AreEqual(10, db.Baskets.Count());
        }
    }
}
