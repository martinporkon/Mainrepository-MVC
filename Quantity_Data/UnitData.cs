
using Sooduskorv_MVC.Data.CommonData;

namespace Quantity.Data
{

    public sealed class UnitData : CommonMetricData {

        public UnitData( ) : this(null) { }
        
        public UnitData(string measureId, string n=null, string c= null, string d= null, UnitType t=UnitType.Unspecified) {
            MeasureId = measureId;
            Name = n;
            Code = c;
            Definition = d;
            UnitType = t;
        }

        public string MeasureId { get; set; }
        
        public UnitType UnitType { get; set; }
    }

}
