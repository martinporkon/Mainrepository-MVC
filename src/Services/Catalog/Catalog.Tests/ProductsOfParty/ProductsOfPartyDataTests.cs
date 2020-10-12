using Catalog.Data.ProductOfParty;
using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.ProductsOfParty
{

    [TestClass]
    public class ProductsOfPartyDataTests : SealedClassTests<ProductsOfPartyData, PeriodData>
    {

        [TestMethod]
        public void ProductIdTest() =>
            isNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void PartyIdTest() =>
            isNullableProperty(() => obj.PartyId, x => obj.PartyId = x);


        [TestMethod]
        public void PriceIdTest() =>
            isNullableProperty(() => obj.PriceId, x => obj.PriceId = x);

    }
}
