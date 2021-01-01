using Catalog.Data.Product;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Product
{

    [TestClass]
    public class ProductTypeDataTests : SealedClassTests<ProductTypeData, DescribedEntityData>
    {

        [TestMethod] public void ProductKindTest() => isProperty<ProductKind>();

        [TestMethod] public void AmountTest() => isProperty<double>();
        [TestMethod] public void UnitIdTest() => isNullableProperty<string>();
        [TestMethod] public void BrandIdTest() => isNullableProperty<string>();
        [TestMethod] public void CountryOfOriginIdTest() => isNullableProperty<string>();
        [TestMethod] public void BarCodeTest() => isNullableProperty<string>();
        [TestMethod] public void ImageTest() => isNullableProperty<string>();

    }

}