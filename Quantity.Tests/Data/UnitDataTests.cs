using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Data
{
    [TestClass]
    public class UnitDataTests: SealedClassTests<UnitData, CommonMetricData>
    {
        [TestMethod]
        public void MeasureIdTest() 
            => isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);


        [TestMethod]
        public void UnitTypeTest()
            => isProperty(() => obj.UnitType, x => obj.UnitType = x);

    }
}
