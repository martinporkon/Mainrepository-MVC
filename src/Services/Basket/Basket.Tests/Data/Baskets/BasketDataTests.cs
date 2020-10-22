using Basket.Data.Baskets;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basket.Tests.Data.Baskets
{
    [TestClass]
    public class BasketDataTests : SealedClassTests<BasketData, NamedEntityData>
    {
        [TestMethod]
        public void CustomerIdTest() =>
           isNullableProperty(() => obj.CustomerId, x => obj.CustomerId = x);
    }
}
