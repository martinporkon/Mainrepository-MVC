using CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass] public class QuantityPagesNamesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(QuantityPagesNames);

        [TestMethod] public void MeasuresTest() => Assert.AreEqual("Measures", QuantityPagesNames.Measures);

        [TestMethod] public void MeasureTermsTest() =>
            Assert.AreEqual("Measure Terms", QuantityPagesNames.MeasureTerms);

        [TestMethod] public void SystemsOfUnitsTest() =>
            Assert.AreEqual("Systems Of Units", QuantityPagesNames.SystemsOfUnits);

        [TestMethod] public void UnitFactorsTest() =>
            Assert.AreEqual("Unit Factors", QuantityPagesNames.UnitFactors);

        [TestMethod] public void UnitsTest() => Assert.AreEqual("Units", QuantityPagesNames.Units);

        [TestMethod] public void UnitTermsTest() => Assert.AreEqual("Unit Terms", QuantityPagesNames.UnitTerms);

    }

}

