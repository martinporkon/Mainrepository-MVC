using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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