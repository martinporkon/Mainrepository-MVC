using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Pages.Common.Consts;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts
{
    [TestClass]
    public class MoneyPagesNamesTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(MoneyPagesNames);
        [TestMethod] public void RatesTest() => Assert.AreEqual("Exchange Rates", MoneyPagesNames.Rates);
        [TestMethod] public void CountriesTest() => Assert.AreEqual("Countries", MoneyPagesNames.Countries);
        [TestMethod] public void CurrencyUsagesTest() => Assert.AreEqual("Currency Usages", MoneyPagesNames.CurrencyUsages);
        [TestMethod] public void CardsTest() => Assert.AreEqual("Payment Card Associations", MoneyPagesNames.Cards);
        [TestMethod] public void CurrenciesTest() => Assert.AreEqual("Currencies", MoneyPagesNames.Currencies);
        [TestMethod] public void RateTypesTest() => Assert.AreEqual("Exchange Rate Types", MoneyPagesNames.RateTypes);
        [TestMethod] public void RateTypeRulesTest() => Assert.AreEqual("Exchange Rate Type Rules", MoneyPagesNames.RateTypeRules);
        [TestMethod] public void PaymentMethodsTest() => Assert.AreEqual("Payment Methods", MoneyPagesNames.PaymentMethods);
        [TestMethod] public void PaymentsTest() => Assert.AreEqual("Payments", MoneyPagesNames.Payments);
        [TestMethod] public void MoneyMenuTest() => Assert.AreEqual("Money", MoneyPagesNames.MoneyMenu);
    }

}
