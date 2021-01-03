using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace CommonTests.DataTests.CommonDataTests
{
    [TestClass]
    public class NamedEntityDataTests : AbstractClassTests<NameEntityData, PeriodData>
    {

        private class testClass : NameEntityData { }

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