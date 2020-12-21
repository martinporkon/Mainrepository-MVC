using CommonData;

namespace Quantity.Data {

    public abstract class UnitAttributeData : PeriodData {

        public string UnitId { get; set; }

        public string SystemOfUnitsId { get; set; }
    }

}