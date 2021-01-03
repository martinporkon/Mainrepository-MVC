using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Data
{
    [TestClass]
    public class MeasureDataTests: SealedClassTests<MeasureData, CommonMetricData>
    {

        [TestMethod] public void MeasureTypeTest() {
            isProperty(() => obj.MeasureType, x => obj.MeasureType= x);
        }
    }

}
