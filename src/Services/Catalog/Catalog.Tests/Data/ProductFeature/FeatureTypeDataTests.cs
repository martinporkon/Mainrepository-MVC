using Catalog.Data.ProductFeature;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.ProductFeature
{

    [TestClass]
    public class FeatureTypeDataTests : SealedClassTests<FeatureTypeData, DescribedEntityData>
    {

        [TestMethod]
        public void ProductTypeIdTest() => isNullableProperty(() => obj.ProductTypeId, x => obj.ProductTypeId = x);

        [TestMethod]
        public void IsMandatoryTest() => isProperty(() => obj.IsMandatory, x => obj.IsMandatory = x);
        [TestMethod] public void NumericCodeTest() => isProperty<int>();

    }

}