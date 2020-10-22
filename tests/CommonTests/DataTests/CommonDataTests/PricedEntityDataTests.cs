using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
{
    [TestClass]
    public class PricedEntityDataTests : AbstractClassTests<PricedEntityData, PeriodData>
    {
        private class testClass : PricedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void PriceTest()
            => isProperty(() => obj.Price, x => obj.Price = x);
    }
}