using CommonData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace Quantity.Tests.Data
{
    [TestClass]
    public class MeasureDataTests: SealedTests<MeasureData, CommonMetricData>
    {

        [TestMethod] public void MeasureTypeTest() {
            isProperty(() => obj.MeasureType, x => obj.MeasureType= x);
        }
    }

}
