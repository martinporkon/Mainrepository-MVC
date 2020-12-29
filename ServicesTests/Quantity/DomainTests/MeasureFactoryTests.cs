using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class MeasureFactoryTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(MeasureFactory);

        [TestMethod] public void CreateTest() =>
            Assert.IsInstanceOfType(MeasureFactory.Create(), typeof(BaseMeasure));

        [TestMethod] public void CreateBaseTest() =>
            Assert.IsInstanceOfType(MeasureFactory.Create(
                new MeasureData {MeasureType = MeasureType.Base}), typeof(BaseMeasure));

        [TestMethod] public void CreateDerivedTest() =>
            Assert.IsInstanceOfType(MeasureFactory.Create(
                new MeasureData {MeasureType = MeasureType.Derived}), typeof(DerivedMeasure));

    }

}
