using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade.Common
{

    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedView, UniqueEntityView>
    {
        private class testClass : NamedView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void NameTest()
        {
            isNullableProperty(() => obj.Name, x => obj.Name = x);
        }
        [TestMethod]
        public void CodeTest()
        {
            isNullableProperty(() => obj.Code, x => obj.Code= x);
        }
    }

}