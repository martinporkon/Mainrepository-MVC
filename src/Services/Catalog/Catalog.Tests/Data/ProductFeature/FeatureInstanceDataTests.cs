using Catalog.Data.ProductFeature;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.ProductFeature
{

    [TestClass]
    public class FeatureInstanceDataTests : SealedClassTests<FeatureInstanceData, FeatureValueData>
    {

        [TestMethod]
        public void FeatureTypeIdTest()
            => isNullableProperty(() => obj.FeatureTypeId, x => obj.FeatureTypeId = x);

        [TestMethod]
        public void ProductIdTest()
            => isNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

    }

}