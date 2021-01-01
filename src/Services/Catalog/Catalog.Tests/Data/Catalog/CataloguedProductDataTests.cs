using Catalog.Data.CatalogedProducts;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Catalog
{

    [TestClass]
    public class CatalogedProductDataTests : SealedClassTests<CatalogedProductData, PeriodData>
    {
        [TestMethod] public void CatalogEntryIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductTypeIdTest() => isNullableProperty<string>();

    }

}