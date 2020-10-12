using CommonData;
using CommonTests.BaseTests;
using Data.CommonData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.CommonEntityTests
{
    [TestClass]
    public class NamedEntityDataTests : AbstractClassTests<NamedEntityData, PeriodData>
    {

        private class testClass : NamedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void NameTest()
            => isNullableProperty(() => obj.Name, x => obj.Name = x);

     

    }
}
