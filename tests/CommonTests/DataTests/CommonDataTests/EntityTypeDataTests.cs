using Aids.Random;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
{

    [TestClass]
    public class EntityTypeDataTests : AbstractClassTests<EntityTypeData, DefinedEntityData>
    {

        private class testClass : EntityTypeData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void BaseTypeIdTest()
            => isNullableProperty(() => obj.BaseTypeId, x => obj.BaseTypeId = x);

    }

}