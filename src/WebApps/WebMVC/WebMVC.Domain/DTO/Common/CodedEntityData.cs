using Sooduskorv_MVC.Data.CommonData;

namespace CommonData
{
    public abstract class CodedEntityData : NamedEntityData
    {
        public string Code { get; set; }
    }
}