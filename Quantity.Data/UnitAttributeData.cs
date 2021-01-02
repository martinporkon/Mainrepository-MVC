using Sooduskorv_MVC.Data.CommonData;

namespace Quantity.Data {

    public abstract class UnitAttributeData : PeriodData {

        public string UnitId { get; set; }

        public string SystemOfUnitsId { get; set; }
    }

}