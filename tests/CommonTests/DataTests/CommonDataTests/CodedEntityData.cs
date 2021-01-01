using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTests.DataTests.CommonDataTests
{
    [TestClass]
    public class CodedEntityDataTests : AbstractClassTests<CodedEntityData, NamedEntityData>
    {
        private class testClass : CodedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void CodeTest()
            => isNullableProperty(() => obj.Code, x => obj.Code = x);
    }
}
