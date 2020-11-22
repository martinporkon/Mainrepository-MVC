using Basket.Data.Baskets;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Tests.Data.Baskets
{
    [TestClass]
    public class BasketDataTests : SealedClassTests<BasketData, NamedEntityData>
    {
        [TestMethod]
        public void CustomerIdTest() =>
           isNullableProperty(() => obj.BuyerId, x => obj.BuyerId = x);
    }
}
