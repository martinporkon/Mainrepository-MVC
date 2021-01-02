using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade.Common
{

    [TestClass] public class EntityTypeViewTests : AbstractClassTests<EntityTypeView, DefinedView> {

        private class testClass : EntityTypeView { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void BaseTypeIdTest()
            => isNullableProperty(() => obj.BaseTypeId, x => obj.BaseTypeId = x);

    }

}
