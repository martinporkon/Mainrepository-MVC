using CommonTests.OverallTests;
using Quantity.Data;

namespace Quantity.Tests.Data
{

    [TestClass]
    public class UnitFactorDataTests : SealedClassTests<UnitFactorData, UnitAttributeData>
    {
        [TestMethod]
        public void FactorTest()
        {
            isProperty(() => obj.Factor, x => obj.Factor = x);
        }

    }

}