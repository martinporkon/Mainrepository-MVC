using Catalog.Data.SubCategories;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.SubCategories
{
    [TestClass]
    public class SubCategoryDataTests : SealedClassTests<SubCategoryData, NamedEntityData>
    {
        [TestMethod]
        public void CategoryIdTest() =>
            isNullableProperty(() => obj.CategoryId, x => obj.CategoryId = x);
    }
}
