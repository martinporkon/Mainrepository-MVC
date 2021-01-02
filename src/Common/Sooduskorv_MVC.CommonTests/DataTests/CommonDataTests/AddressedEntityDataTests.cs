using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace CommonTests.DataTests.CommonDataTests
{
    [TestClass]
    public class AddressedEntityDataTests : AbstractClassTests<AddressedEntityData, PeriodData>
    {
        private class testClass : AddressedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void AddressIdTest()
            => isNullableProperty(() => obj.AddressId, x => obj.AddressId = x);
    }
}