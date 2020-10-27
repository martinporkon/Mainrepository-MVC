using Catalog.Data.Products;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Tests.Data.Products
{

    [TestClass]
    public class ProductDataTests : SealedClassTests<ProductData, DescribedEntityData>
    {
        [TestMethod]
        public void CategoryIdTest() =>
            isNullableProperty(() => obj.CategoryId, x => obj.CategoryId = x);

        [TestMethod]
        public void SubCategoryIdTest() =>
            isNullableProperty(() => obj.SubCategoryId, x => obj.SubCategoryId = x);

        [TestMethod]
        public void TypeTest() =>
            isNullableProperty(() => obj.Type, x => obj.Type = x);

        [TestMethod]
        public void BrandTest() =>
            isNullableProperty(() => obj.Brand, x => obj.Brand = x);

        [TestMethod]
        public void SupplierTest() =>
            isNullableProperty(() => obj.Supplier, x => obj.Supplier = x);

        [TestMethod]
        public void CountryOfOriginTest() =>
            isNullableProperty(() => obj.CountryOfOrigin, x => obj.CountryOfOrigin = x);

        [TestMethod]
        public void MeasureTest() =>
            isNullableProperty(() => obj.Measure, x => obj.Measure = x);

        [TestMethod]
        public void AmountTest() =>
            isNullableProperty(() => obj.Amount, x => obj.Amount = x);

        [TestMethod]
        public void CodeTest() =>
            isNullableProperty(() => obj.Code, x => obj.Code = x);

        [TestMethod]
        public void DescriptionTest() =>
            isNullableProperty(() => obj.Description, x => obj.Description = x);

        [TestMethod]
        public void CompositionTest() =>
            isNullableProperty(() => obj.Composition, x => obj.Composition = x);

        [TestMethod]
        public void ImageTest() =>
            isNullableProperty(() => obj.Image, x => obj.Image = x);
    }
}
