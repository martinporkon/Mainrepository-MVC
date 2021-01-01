using Aids.Random;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
{

    [TestClass]
    public class RelationshipTypeDataTests : AbstractClassTests<RelationshipTypeData, EntityTypeData>
    {

        private class testClass : RelationshipTypeData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }

        [TestMethod] public void ConsumerTypeIdTest() => isNullableProperty<string>();

        [TestMethod] public void ProviderTypeIdTest() => isNullableProperty<string>();

    }

}