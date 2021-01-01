using Aids.Random;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
{

    [TestClass]

    public class RelationshipDataTests : AbstractClassTests<RelationshipData, DefinedEntityData>
    {

        private class testClass : RelationshipData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }

        [TestMethod] public void RelationshipTypeIdTest() => isNullableProperty<string>();
        [TestMethod]
        public void ConsumerEntityIdTest() => isNullableProperty<string>();
        [TestMethod]
        public void ProviderEntityIdTest() => isNullableProperty<string>();

    }

}
