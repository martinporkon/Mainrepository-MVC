using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Pages.Common.Consts;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts
{

    [TestClass]
    public class ProductPagesUrlsTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(ProductPagesUrls);
        [TestMethod] public void ProductsTest() => Assert.AreEqual("/Products/Products", ProductPagesUrls.Products);
        [TestMethod] public void FeatureTypesTest() => Assert.AreEqual("/Products/FeatureTypes", ProductPagesUrls.FeatureTypes);
        [TestMethod] public void FeaturesTest() => Assert.AreEqual("/Products/Features", ProductPagesUrls.Features);
        [TestMethod] public void PossibleFeatureValuesTest() => Assert.AreEqual("/Products/PossibleFeatureValues", ProductPagesUrls.PossibleFeatureValues);
        [TestMethod] public void ProductTypesTest() => Assert.AreEqual("/Products/ProductTypes", ProductPagesUrls.ProductTypes);
        [TestMethod] public void CatalogsTest() => Assert.AreEqual("/Products/Catalogs", ProductPagesUrls.Catalogs);
        [TestMethod] public void InventoryTest() => Assert.AreEqual("/Products/Inventory", ProductPagesUrls.Inventory);
        [TestMethod] public void ProductCategoriesTest() => Assert.AreEqual("/Products/ProductCategories", ProductPagesUrls.ProductCategories);
        [TestMethod] public void BatchesTest() => Assert.AreEqual("/Products/Batches", ProductPagesUrls.Batches);
    }

}