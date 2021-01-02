using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.Quantities
{

    public sealed class UnitData : DescribedEntityData
    {

        public UnitData() : this(null) { }

        public UnitData(string measureId, string n = null, string c = null, string d = null, UnitType t = UnitType.Unspecified)
        {
            MeasureId = measureId;
            Name = n;
            Description = d;
            UnitType = t;
        }

        public string MeasureId { get; set; }

        public UnitType UnitType { get; set; }
    }

}
