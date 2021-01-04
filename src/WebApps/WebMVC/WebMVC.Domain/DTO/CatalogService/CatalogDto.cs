using Sooduskorv_MVC.Data.CommonData;


namespace Web.Domain.DTO.CatalogService
{
    public class CatalogDto : PeriodData        
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}