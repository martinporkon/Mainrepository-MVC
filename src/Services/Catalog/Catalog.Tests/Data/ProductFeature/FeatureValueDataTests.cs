using Aids.Random;
using Catalog.Data.ProductFeature;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Tests.Data.ProductFeature
{

    [TestClass]
    public class FeatureValueDataTests : AbstractClassTests<FeatureValueData, UniqueEntityData>
    {

        private class testClass : FeatureValueData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }

        [TestMethod] public void ValueTest() => isNullableProperty<ValueData>();

        [TestMethod] public void FeatureTypeIdTest() => isNullableProperty<string>();

    }

}
