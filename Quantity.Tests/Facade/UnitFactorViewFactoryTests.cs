using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Sooduskorv_MVC.Aids.Random;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade
{

    [TestClass] public class UnitFactorViewFactoryTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(UnitFactorViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() {
            var view = GetRandom.Object<UnitFactorView>();
            var data = UnitFactorViewFactory.Create(view).Data;

            arePropertiesEqual(view, data);

        }

        [TestMethod] public void CreateViewTest() {
            var data = GetRandom.Object<UnitFactorData>();
            var view = UnitFactorViewFactory.Create(new UnitFactor(data));

            arePropertiesEqual(view, data);

        }

    }

}
