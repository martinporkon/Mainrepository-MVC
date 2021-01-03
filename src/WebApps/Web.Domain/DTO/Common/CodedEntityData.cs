using Sooduskorv_MVC.Data.CommonData;

namespace Web.Domain.DTO.Common
{
    public abstract class CodedEntityData : NameEntityData
    {
        public string Code { get; set; }
    }
}