using CommonData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace ServicesTests.Quantity.DataTests
{
    [TestClass]
    public class MeasureDataTests: SealedTests<MeasureData, CommonMetricData>
    {

        [TestMethod] public void MeasureTypeTest() {
            isProperty(() => obj.MeasureType, x => obj.MeasureType= x);
        }
    }

}
