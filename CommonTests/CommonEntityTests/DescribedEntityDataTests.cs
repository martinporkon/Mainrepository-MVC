﻿using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sooduskorv.Tests.Data.Common
{
    [TestClass]
    public class DescribedEntityDataTests : AbstractClassTests<DescribedEntityData, NamedEntityData>
    {
        private class testClass : DescribedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void DescriptionTest()
            => isNullableProperty(() => obj.Description, x => obj.Description = x);
    }
}
