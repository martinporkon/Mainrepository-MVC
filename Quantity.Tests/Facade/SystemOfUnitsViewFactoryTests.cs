using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Sooduskorv_MVC.Aids.Random;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade
{

    [TestClass] public class SystemOfUnitsViewFactoryTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(SystemOfUnitsViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() {
            var view = GetRandom.Object<SystemOfUnitsView>();
            var data = SystemOfUnitsViewFactory.Create(view).Data;

            arePropertiesEqual(view, data);

        }

        [TestMethod] public void CreateViewTest() {
            var data = GetRandom.Object<SystemOfUnitsData>();
            var view = SystemOfUnitsViewFactory.Create(new SystemOfUnits(data));

            arePropertiesEqual(view, data);

        }

    }

}
