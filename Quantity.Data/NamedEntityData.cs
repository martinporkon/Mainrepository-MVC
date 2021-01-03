using Sooduskorv_MVC.Data.CommonData;

namespace Quantity.Data
{

    public abstract class NamedEntityData : PeriodData
    {

        public string Code { get; set; }
        public string Name { get; set; }

    }

}
