using CommonTests.OverallTests;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;

namespace Quantity.Tests.Facade {

    [TestClass] public class UnitViewFactoryTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(UnitViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() {
            var view = GetRandom.Object<UnitView>();
            var data = UnitViewFactory.Create(view).Data;

            arePropertiesEqual(view, data);

        }

        [TestMethod] public void CreateViewTest() {
            var data = GetRandom.Object<UnitData>();
            if (data.UnitType == UnitType.Error) data.UnitType = UnitType.Factored;
            else if (data.UnitType == UnitType.Unspecified) data.UnitType = UnitType.Derived;

            var view = UnitViewFactory.Create(UnitFactory.Create(data));

            arePropertiesEqual(view, data);

        }

    }

}
