using CommonTests.OverallTests;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;

namespace Quantity.Tests.Facade {

    [TestClass] public class MeasureTermViewFactoryTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(MeasureTermViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() {
            var view = GetRandom.Object<MeasureTermView>();
            var data = MeasureTermViewFactory.Create(view).Data;

            arePropertiesEqual(view, data);

        }

        [TestMethod] public void CreateViewTest() {
            var data = GetRandom.Object<MeasureTermData>();
            var view = MeasureTermViewFactory.Create(new MeasureTerm(data));

            arePropertiesEqual(view, data);

        }

    }

}
