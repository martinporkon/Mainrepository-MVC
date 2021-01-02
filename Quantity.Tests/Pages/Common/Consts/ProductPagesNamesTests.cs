using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Pages.Common.Consts;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts
{

    [TestClass]
    public class ProductPagesNamesTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(ProductPagesNames);
        [TestMethod] public void ProductsTest() => Assert.AreEqual("Products", ProductPagesNames.Products);
        [TestMethod] public void FeatureTypesTest() => Assert.AreEqual("Feature Types", ProductPagesNames.FeatureTypes);
        [TestMethod] public void FeaturesTest() => Assert.AreEqual("Features", ProductPagesNames.Features);
        [TestMethod] public void PossibleFeatureValuesTest() => Assert.AreEqual("Possible Feature Values", ProductPagesNames.PossibleFeatureValues);
        [TestMethod] public void ProductTypesTest() => Assert.AreEqual("Product Types", ProductPagesNames.ProductTypes);
        [TestMethod] public void CatalogsTest() => Assert.AreEqual("Catalogs", ProductPagesNames.Catalogs);
        [TestMethod] public void InventoryTest() => Assert.AreEqual("Inventory", ProductPagesNames.Inventory);
        [TestMethod] public void ProductCategoriesTest() => Assert.AreEqual("Product Categories", ProductPagesNames.ProductCategories);
        [TestMethod] public void BatchesTest() => Assert.AreEqual("Batches", ProductPagesNames.Batches);
    }

}