using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Sooduskorv_MVC.CommonTests.OverallTests;

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