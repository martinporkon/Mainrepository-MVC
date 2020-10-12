using CommonData;
using CommonTests.BaseTests;
using Data.CommonData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.CommonEntityTests
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



        //[TestMethod] public void ValidFromTest() => isNullableProperty<DateTime?>();

        //[TestMethod] public void ValidToTest() => isNullableProperty<DateTime?>();

    }
}
