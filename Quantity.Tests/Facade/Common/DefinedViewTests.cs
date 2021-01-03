using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade.Common
{

    [TestClass] public class DefinedViewTests : AbstractClassTests<DefinedView, NamedView> {

        private class testClass : DefinedView { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void DefinitionTest() {
            isNullableProperty(() => obj.Definition, x => obj.Definition = x);
        }

    }

}