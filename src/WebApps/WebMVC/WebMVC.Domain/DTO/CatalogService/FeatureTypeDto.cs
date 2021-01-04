using Sooduskorv_MVC.Data.CommonData;

namespace Web.Domain.DTO.CatalogService
{
    public class FeatureTypeDto : DescribedEntityData
    {
        public string ProductTypeId { get; set; }

        public bool IsMandatory { get; set; }

        public int NumericCode { get; set; }
    }
}