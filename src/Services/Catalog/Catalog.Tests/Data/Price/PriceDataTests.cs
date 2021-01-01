using Catalog.Data.Price;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Price
{

    [TestClass]
    public class PriceDataTests : SealedClassTests<PriceData, NamedEntityData>
    {

        [TestMethod] public void AmountTest() => isProperty<decimal>();
        [TestMethod] public void CurrencyIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductInstanceIdTest() => isNullableProperty<string>();
       

    }

}