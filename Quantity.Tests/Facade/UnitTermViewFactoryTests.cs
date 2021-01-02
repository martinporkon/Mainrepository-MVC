using CommonTests.OverallTests;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;

namespace Quantity.Tests.Facade {

    [TestClass] public class UnitTermViewFactoryTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(UnitTermViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() {
            var view = GetRandom.Object<UnitTermView>();
            var data = UnitTermViewFactory.Create(view).Data;

            arePropertiesEqual(view, data);

        }

        [TestMethod] public void CreateViewTest() {
            var data = GetRandom.Object<UnitTermData>();
            var view = UnitTermViewFactory.Create(new UnitTerm(data));

            arePropertiesEqual(view, data);

        }

    }

}
