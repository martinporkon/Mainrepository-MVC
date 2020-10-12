using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sooduskorv.Tests.Data.Common
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
