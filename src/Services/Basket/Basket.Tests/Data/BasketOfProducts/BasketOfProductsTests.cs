using Basket.Data.BasketOfProducts;
using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basket.Tests.Data.BasketOfProducts
{
    [TestClass]
    public class BasketOfProductsDataTests : SealedClassTests<BasketOfProductsData, PeriodData>
    {

        [TestMethod]
        public void BasketIdTest() =>
            isNullableProperty(() => obj.BasketId, x => obj.BasketId = x);

        [TestMethod]
        public void ProductOfPartyIdTest() =>
            isNullableProperty(() => obj.ProductOfPartyId, x => obj.ProductOfPartyId = x);
    }
}
