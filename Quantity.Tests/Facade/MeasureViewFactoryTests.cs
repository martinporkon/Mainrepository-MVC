using Aids.Random;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;

namespace Quantity.Tests.Facade {

    [TestClass] public class MeasureViewFactoryTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(MeasureViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() {
            var view = GetRandom.Object<MeasureView>();
            var data = MeasureViewFactory.Create(view).Data;

            arePropertiesEqual(view, data);

        }

        [TestMethod] public void CreateViewTest() {
            var data = GetRandom.Object<MeasureData>();
            if (data.MeasureType == MeasureType.Error) data.MeasureType = MeasureType.Base;
            else if (data.MeasureType == MeasureType.Unspecified) data.MeasureType = MeasureType.Derived;
            var view = MeasureViewFactory.Create(MeasureFactory.Create(data));

            arePropertiesEqual(view, data);

        }

    }

}
