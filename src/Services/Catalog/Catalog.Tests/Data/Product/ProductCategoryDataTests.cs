using Catalog.Data.Product;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Product
{

    [TestClass]
    public class ProductCategoryDataTests : SealedClassTests<ProductCategoryData, DescribedEntityData>
    {
        [TestMethod] public void BaseCategoryIdTest() => isNullableProperty<string>();

    }

}