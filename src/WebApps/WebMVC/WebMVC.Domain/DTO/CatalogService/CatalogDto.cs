using Web.Domain.DTO.Common;

namespace Web.Domain.DTO.CatalogService
{
    public class CatalogDto : UniqueEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}