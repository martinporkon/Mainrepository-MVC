using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace ServicesTests.Quantity.DataTests
{

    [TestClass]
    public class UnitFactorDataTests : SealedTests<UnitFactorData, UnitAttributeData>
    {
        [TestMethod]
        public void FactorTest()
        {
            isProperty(() => obj.Factor, x => obj.Factor = x);
        }

    }

}