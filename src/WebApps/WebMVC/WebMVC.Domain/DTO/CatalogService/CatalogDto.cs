using Sooduskorv_MVC.Data.CommonData;
using Web.Domain.DTO.Common;
using UniqueEntityData = Web.Domain.DTO.Common.UniqueEntityData;

namespace Web.Domain.DTO.CatalogService
{
    public class CatalogDto : UniqueEntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}