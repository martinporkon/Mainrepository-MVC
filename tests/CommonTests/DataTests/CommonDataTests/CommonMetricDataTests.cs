using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.DataTests.CommonDataTests
{

    [TestClass]
    public class CommonMetricDataTests : AbstractClassTests<CommonMetricData, DefinedEntityData>
    {

        private class testClass : CommonMetricData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

    }

}
