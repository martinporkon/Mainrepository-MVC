using CommonData;

namespace Catalog.Data.Quantities
{

    public abstract class UnitAttributeData : PeriodData
    {

        public string UnitId { get; set; }

        public string SystemOfUnitsId { get; set; }
    }

}