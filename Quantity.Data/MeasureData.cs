
using CommonData;

namespace Quantity.Data {

    public sealed class MeasureData : CommonMetricData {

        public MeasureData(): this(null) { }
 
        public MeasureData(string n=null, string c=null, string d=null, MeasureType t = MeasureType.Unspecified) {
            Name = n;
            Code = c;
            Definition = d;
            MeasureType = t;
        }
        
        public MeasureType MeasureType { get; set; }

    }

}
