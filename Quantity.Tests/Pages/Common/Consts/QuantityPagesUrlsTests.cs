using Abc.Pages.Common.Consts;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass] public class QuantityPagesUrlsTests : BaseTests {

        [TestInitialize] public void TestInitialize() {
            type = typeof(QuantityPagesUrls);
        }

        [TestMethod] public void MeasuresTest() => Assert.AreEqual("/Quantity/Measures", QuantityPagesUrls.Measures);

        [TestMethod] public void MeasureTermsTest() =>
            Assert.AreEqual("/Quantity/MeasureTerms", QuantityPagesUrls.MeasureTerms);

        [TestMethod] public void SystemsOfUnitsTest() =>
            Assert.AreEqual("/Quantity/SystemsOfUnits", QuantityPagesUrls.SystemsOfUnits);

        [TestMethod] public void UnitFactorsTest() =>
            Assert.AreEqual("/Quantity/UnitFactors", QuantityPagesUrls.UnitFactors);

        [TestMethod] public void UnitsTest() =>
            Assert.AreEqual("/Quantity/Units", QuantityPagesUrls.Units);

        [TestMethod] public void UnitTermsTest() =>
            Assert.AreEqual("/Quantity/UnitTerms", QuantityPagesUrls.UnitTerms);

    }

}
