using Sooduskorv_MVC.Data.CommonData;

namespace WebMVC.Bff.HttpAggregator.Data.Resources
{
    public class ResourceData : PeriodData
    {
        public string ImageByte { get; set; }
        public string ImageInformationId { get; set; }
        public string FileExtensionId { get; set; }
        public string Id { get; set; }
    }
}