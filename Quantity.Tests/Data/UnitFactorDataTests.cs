using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace Quantity.Tests.Data
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