using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
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