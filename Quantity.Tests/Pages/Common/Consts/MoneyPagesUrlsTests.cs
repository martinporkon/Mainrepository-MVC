using CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass]
    public class MoneyPagesUrlsTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(MoneyPagesUrls);
        [TestMethod] public void CountriesTest() => Assert.AreEqual("/Money/Countries", MoneyPagesUrls.Countries);
        [TestMethod] public void CardsTest() => Assert.AreEqual("/Money/Cards", MoneyPagesUrls.Cards);
        [TestMethod] public void CurrenciesTest() => Assert.AreEqual("/Money/Currencies", MoneyPagesUrls.Currencies);
        [TestMethod] public void CurrencyUsagesTest() => Assert.AreEqual("/Money/CurrencyUsages", MoneyPagesUrls.CurrencyUsages);
        [TestMethod] public void RateTypesTest() => Assert.AreEqual("/Money/RateTypes", MoneyPagesUrls.RateTypes);
        [TestMethod] public void RateTypesRulesTest() => Assert.AreEqual("/Money/RateTypesRules", MoneyPagesUrls.RateTypesRules);
        [TestMethod] public void RatesTest() => Assert.AreEqual("/Money/Rates", MoneyPagesUrls.Rates);
        [TestMethod] public void PaymentMethodsTest() => Assert.AreEqual("/Money/PaymentMethods", MoneyPagesUrls.PaymentMethods);
        [TestMethod] public void PaymentsTest() => Assert.AreEqual("/Money/Payments", MoneyPagesUrls.Payments);
    }

}