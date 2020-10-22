using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
{
    [TestClass]
    public class DescribedEntityDataTests : AbstractClassTests<DescribedEntityData, NamedEntityData>
    {
        private class testClass : DescribedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void DescriptionTest()
            => isNullableProperty(() => obj.Description, x => obj.Description = x);
    }
}