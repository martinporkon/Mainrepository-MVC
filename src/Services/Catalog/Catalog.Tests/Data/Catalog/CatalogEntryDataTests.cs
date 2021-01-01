using Catalog.Data.CatalogEntries;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Catalog
{

    [TestClass]
    public class CatalogEntryDataTests : SealedClassTests<CatalogEntryData, DescribedEntityData>
    {

        [TestMethod] public void CatalogIdTest() => isNullableProperty<string>();
        [TestMethod] public void CategoryIdTest() => isNullableProperty<string>();

    }

}