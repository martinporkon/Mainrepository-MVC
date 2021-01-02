using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.Quantities
{

    public sealed class MeasureData : DescribedEntityData
    {

        public MeasureData() : this(null) { }

        public MeasureData(string n = null, string c = null, string d = null, MeasureType t = MeasureType.Unspecified)
        {
            Name = n;
            Description = d;
            MeasureType = t;
        }

        public MeasureType MeasureType { get; set; }

    }

}
