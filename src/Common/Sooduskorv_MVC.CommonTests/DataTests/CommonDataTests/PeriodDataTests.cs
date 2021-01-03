using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace CommonTests.DataTests.CommonDataTests
{

    [TestClass]
    public class PeriodDataTests : AbstractClassTests<PeriodData, UniqueEntityData>
    {
        private class testClass : PeriodData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void ValidFromTest()
            => isNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);

        [TestMethod]
        public void ValidToTest()
            => isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x);

    }
}