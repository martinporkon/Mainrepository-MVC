using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Data.CommonData;

namespace CommonTests.DataTests.CommonDataTests
{

    [TestClass]
    public class UniqueEntityDataTests : AbstractClassTests<UniqueEntityData, object>
    {

        private class testClass : UniqueEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void IdTest()
            => isNullableProperty(() => obj.Id, x => obj.Id = x);

    }
}