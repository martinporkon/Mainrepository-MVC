using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace CommonTests.DataTests.CommonDataTests
{
    [TestClass]
    public class DescribedEntityDataTests : AbstractClassTests<DescribedEntityData, NameEntityData>
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