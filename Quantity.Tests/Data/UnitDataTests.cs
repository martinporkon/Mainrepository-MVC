using CommonData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace Quantity.Tests.Data
{
    [TestClass]
    public class UnitDataTests: SealedTests<UnitData, CommonMetricData>
    {
        [TestMethod]
        public void MeasureIdTest() 
            => isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);


        [TestMethod]
        public void UnitTypeTest()
            => isProperty(() => obj.UnitType, x => obj.UnitType = x);

    }
}
