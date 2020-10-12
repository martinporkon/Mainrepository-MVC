using CommonData;
using CommonTests.BaseTests;
using Data.CommonData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.CommonEntityTests
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
