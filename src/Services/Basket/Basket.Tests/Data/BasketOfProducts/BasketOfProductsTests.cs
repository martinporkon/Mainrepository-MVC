using Basket.Data.BasketOfProducts;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Tests.Data.BasketOfProducts
{
    [TestClass]
    public class BasketOfProductsDataTests : SealedClassTests<BasketOfProductData, PeriodData>
    {

        [TestMethod]
        public void BasketIdTest() =>
            isNullableProperty(() => obj.BasketId, x => obj.BasketId = x);

        [TestMethod]
        public void ProductOfPartyIdTest() =>
            isNullableProperty(() => obj.ProductOfPartyId, x => obj.ProductOfPartyId = x);
    }
}
